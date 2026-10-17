#include "Media/BundledH264Decoder.h"
#include "Media/H264.h"

#include <Windows.h>
#include <algorithm>
#include <array>
#include <cstring>
#include <filesystem>
#include <format>
#include <limits>
#include <stdexcept>

namespace iPhoneMirror::media {
namespace {

// Public ABI prefixes from the pinned LGPL FFmpeg runtime in
// third_party/airplay-server/BUILD.json (libavcodec 58 / libavutil 56).
// Objects are allocated/freed by FFmpeg, never using sizeof these views.
// Reject other ABI majors before reading any field. See that directory's
// SOURCE.md and LICENSE-FFMPEG-LGPL-2.1.txt for source and license details.
struct AvPacket {
    void* buffer;
    std::int64_t pts, dts;
    std::uint8_t* data;
    int size;
};
struct AvFrame {
    std::uint8_t* data[8];
    int linesize[8];
    std::uint8_t** extended_data;
    int width, height, samples, format, key_frame, picture_type;
    int aspect_numerator, aspect_denominator;
    std::int64_t pts;
};
static_assert(offsetof(AvFrame, pts) == 136);
static_assert(offsetof(AvPacket, data) == 24);
constexpr int Again = -11;
constexpr int EndOfFile = -541478725;

template <typename Function>
Function symbol(HMODULE module, const char* name) {
    const auto address = GetProcAddress(module, name);
    if (!address) throw std::runtime_error(std::string("FFmpeg export missing: ") + name);
    return reinterpret_cast<Function>(address);
}

struct Runtime {
    HMODULE util{}, codec{};
    const void* decoder{};
    void* (*allocate_context)(const void*){};
    int (*open_context)(void*, const void*, void*){};
    void (*free_context)(void**){};
    AvPacket* (*allocate_packet)(){};
    int (*new_packet)(AvPacket*, int){};
    void (*unref_packet)(AvPacket*){};
    void (*free_packet)(AvPacket**){};
    int (*send_packet)(void*, const AvPacket*){};
    int (*receive_frame)(void*, AvFrame*){};
    void (*flush_context)(void*){};
    AvFrame* (*allocate_frame)(){};
    void (*unref_frame)(AvFrame*){};
    void (*free_frame)(AvFrame**){};
    int (*set_integer)(void*, const char*, std::int64_t, int){};
    int (*pixel_format)(const char*){};

    explicit Runtime(const std::filesystem::path& directory) {
        const auto load = [&directory](const wchar_t* name) {
            return LoadLibraryExW((directory / name).c_str(), nullptr,
                LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR | LOAD_LIBRARY_SEARCH_SYSTEM32);
        };
        try {
            util = load(L"avutil-56.dll");
            codec = load(L"avcodec-58.dll");
            if (!util || !codec) throw std::runtime_error("bundled FFmpeg runtime unavailable");
            if ((symbol<unsigned (*)()>(util, "avutil_version")() >> 16U) != 56 ||
                (symbol<unsigned (*)()>(codec, "avcodec_version")() >> 16U) != 58)
                throw std::runtime_error("bundled FFmpeg ABI mismatch");
            decoder = symbol<const void* (*)(const char*)>(codec, "avcodec_find_decoder_by_name")("h264");
            if (!decoder) throw std::runtime_error("bundled H.264 decoder unavailable");
#define LOAD(member, module, name) member = symbol<decltype(member)>(module, name)
            LOAD(allocate_context, codec, "avcodec_alloc_context3");
            LOAD(open_context, codec, "avcodec_open2");
            LOAD(free_context, codec, "avcodec_free_context");
            LOAD(allocate_packet, codec, "av_packet_alloc");
            LOAD(new_packet, codec, "av_new_packet");
            LOAD(unref_packet, codec, "av_packet_unref");
            LOAD(free_packet, codec, "av_packet_free");
            LOAD(send_packet, codec, "avcodec_send_packet");
            LOAD(receive_frame, codec, "avcodec_receive_frame");
            LOAD(flush_context, codec, "avcodec_flush_buffers");
            LOAD(allocate_frame, util, "av_frame_alloc");
            LOAD(unref_frame, util, "av_frame_unref");
            LOAD(free_frame, util, "av_frame_free");
            LOAD(set_integer, util, "av_opt_set_int");
            LOAD(pixel_format, util, "av_get_pix_fmt");
#undef LOAD
        } catch (...) {
            release();
            throw;
        }
    }
    void release() noexcept {
        if (codec) FreeLibrary(codec);
        if (util) FreeLibrary(util);
        codec = util = nullptr;
    }
    ~Runtime() { release(); }
};

std::shared_ptr<Runtime> runtime() noexcept {
    static const auto instance = []() -> std::shared_ptr<Runtime> {
        try {
            HMODULE module{};
            GetModuleHandleExW(GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS |
                GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT,
                reinterpret_cast<LPCWSTR>(&runtime), &module);
            std::array<wchar_t, 32768> path{};
            const auto length = GetModuleFileNameW(module, path.data(), static_cast<DWORD>(path.size()));
            if (!length || length >= path.size()) return {};
            // Absolute paths only: never search the working directory or PATH.
            const auto directory = std::filesystem::path(path.data()).parent_path() / L"Wireless";
            return std::make_shared<Runtime>(directory);
        } catch (...) {
            return {};
        }
    }();
    return instance;
}

void checked(int result, const char* operation) {
    if (result < 0) throw std::runtime_error(std::format("FFmpeg {} failed: {}", operation, result));
}
} // namespace

struct BundledH264Decoder::Impl {
    std::shared_ptr<Runtime> api{runtime()};
    coremedia::FormatDescription format;
    void* context{};
    AvPacket* packet{};
    AvFrame* frame{};
    bool parameter_sets_sent{};

    explicit Impl(const coremedia::FormatDescription& value) : format(value) {
        if (!api || value.video_codec() != coremedia::VideoCodec::H264 ||
            value.chroma_format != 3 || value.bit_depth_luma != 8 || value.bit_depth_chroma != 8 ||
            !detail::checked_video_buffer_size(value.width, value.height, PixelFormat::Nv12))
            throw std::runtime_error("bundled H.264 decoder unavailable or invalid dimensions");
        try {
            context = api->allocate_context(api->decoder);
            packet = api->allocate_packet();
            frame = api->allocate_frame();
            if (!context || !packet || !frame) throw std::bad_alloc();
            checked(api->set_integer(context, "threads", 2, 0), "set decoder threads");
            // Slice threading avoids a frame-thread delay for screen mirroring.
            checked(api->set_integer(context, "thread_type", 2, 0), "set decoder threading");
            checked(api->open_context(context, api->decoder, nullptr), "open H.264 decoder");
        } catch (...) {
            release();
            throw;
        }
    }
    void release() noexcept {
        if (!api) return;
        if (frame) api->free_frame(&frame);
        if (packet) api->free_packet(&packet);
        if (context) api->free_context(&context);
    }
    ~Impl() { release(); }

    void receive(std::vector<DecodedFrame>& result) {
        for (;;) {
            const auto rc = api->receive_frame(context, frame);
            if (rc == Again || rc == EndOfFile) return;
            checked(rc, "receive frame");
            if (frame->width != static_cast<int>(format.width) ||
                frame->height != static_cast<int>(format.height) || !frame->data[0])
                throw std::runtime_error("H.264 decoded dimensions do not match source format");
            const bool jpeg_range = frame->format == api->pixel_format("yuvj444p");
            if ((!jpeg_range && frame->format != api->pixel_format("yuv444p")) ||
                !frame->data[1] || !frame->data[2])
                throw std::runtime_error("expected planar 8-bit AVC 4:4:4 frame");
            for (int plane = 0; plane < 3; ++plane)
                if (frame->linesize[plane] == std::numeric_limits<int>::min() ||
                    std::abs(frame->linesize[plane]) < frame->width)
                    throw std::runtime_error("invalid decoded AVC 4:4:4 plane stride");
            const auto full_range = jpeg_range || format.color.range == coremedia::ColorRange::Full;
            DecodedFrame decoded;
            decoded.width = format.width;
            decoded.height = format.height;
            decoded.stride = static_cast<int>((format.width + 31U) & ~31U);
            decoded.timestamp_100ns = frame->pts;
            decoded.color = format.color;
            decoded.color.range = full_range ? coremedia::ColorRange::Full : coremedia::ColorRange::Limited;
            const auto y_bytes = static_cast<std::size_t>(decoded.stride) * format.height;
            decoded.nv12.resize(y_bytes + static_cast<std::size_t>(decoded.stride) * ((format.height + 1U) / 2U));
            // Preserve every luma pixel and the source range. Only chroma is
            // box-filtered to the existing NV12 renderer's 4:2:0 layout. A
            // generic YUV converter can silently remap full-range to limited.
            for (int y = 0; y < frame->height; ++y)
                std::memcpy(decoded.nv12.data() + static_cast<std::size_t>(y) * decoded.stride,
                    frame->data[0] + static_cast<std::ptrdiff_t>(y) * frame->linesize[0], format.width);
            for (int y = 0; y < frame->height; y += 2) {
                const auto next_y = std::min(y + 1, frame->height - 1);
                auto* uv = decoded.nv12.data() + y_bytes + static_cast<std::size_t>(y / 2) * decoded.stride;
                for (int x = 0; x < frame->width; x += 2) {
                    const auto next_x = std::min(x + 1, frame->width - 1);
                    for (int plane = 1; plane <= 2; ++plane) {
                        const auto* row = frame->data[plane] + static_cast<std::ptrdiff_t>(y) * frame->linesize[plane];
                        const auto* next = frame->data[plane] + static_cast<std::ptrdiff_t>(next_y) * frame->linesize[plane];
                        uv[x + plane - 1] = static_cast<std::uint8_t>((row[x] + row[next_x] + next[x] + next[next_x] + 2) / 4);
                    }
                }
            }
            api->unref_frame(frame);
            result.push_back(std::move(decoded));
        }
    }
    std::vector<DecodedFrame> decode(std::span<const std::uint8_t> sample, std::int64_t timestamp) {
        auto bytes = h264::avcc_to_annex_b(sample, format.nalu_length_size);
        if (!parameter_sets_sent) {
            std::vector<std::uint8_t> headers;
            const auto append = [&headers](const auto& sets) {
                for (const auto& nalu : sets) {
                    headers.insert(headers.end(), {0, 0, 0, 1});
                    headers.insert(headers.end(), nalu.begin(), nalu.end());
                }
            };
            append(format.sequence_parameter_sets);
            append(format.picture_parameter_sets);
            headers.insert(headers.end(), bytes.begin(), bytes.end());
            bytes = std::move(headers);
        }
        if (bytes.size() > static_cast<std::size_t>(std::numeric_limits<int>::max()))
            throw std::runtime_error("H.264 sample exceeds packet size limit");
        api->unref_packet(packet);
        checked(api->new_packet(packet, static_cast<int>(bytes.size())), "allocate packet");
        std::memcpy(packet->data, bytes.data(), bytes.size());
        packet->pts = timestamp;
        packet->dts = timestamp;
        std::vector<DecodedFrame> result;
        auto rc = api->send_packet(context, packet);
        if (rc == Again) {
            receive(result);
            rc = api->send_packet(context, packet);
        }
        checked(rc, "send packet");
        parameter_sets_sent = true;
        receive(result);
        return result;
    }
};

bool BundledH264Decoder::available() noexcept { return static_cast<bool>(runtime()); }
BundledH264Decoder::BundledH264Decoder(const coremedia::FormatDescription& format)
    : impl_(std::make_unique<Impl>(format)) {}
BundledH264Decoder::~BundledH264Decoder() = default;
std::vector<DecodedFrame> BundledH264Decoder::decode(
    std::span<const std::uint8_t> sample, std::int64_t timestamp) {
    return impl_->decode(sample, timestamp);
}
std::vector<DecodedFrame> BundledH264Decoder::drain() {
    std::vector<DecodedFrame> result;
    const auto rc = impl_->api->send_packet(impl_->context, nullptr);
    if (rc != EndOfFile) checked(rc, "drain decoder");
    impl_->receive(result);
    return result;
}
void BundledH264Decoder::flush() {
    impl_->api->flush_context(impl_->context);
    impl_->parameter_sets_sent = false;
}

} // namespace iPhoneMirror::media
