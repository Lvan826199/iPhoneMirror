#pragma once

#include "Media/MediaFoundationDecoder.h"

namespace iPhoneMirror::media {

// The bundled AirPlay FFmpeg runtime also decodes High 4:4:4 Predictive AVC,
// which the Windows H.264 MFT cannot decode. Only advertise that capability
// after the matching runtime and decoder have been found.
class BundledH264Decoder {
public:
    [[nodiscard]] static bool available() noexcept;
    explicit BundledH264Decoder(const coremedia::FormatDescription& format);
    ~BundledH264Decoder();
    BundledH264Decoder(const BundledH264Decoder&) = delete;
    BundledH264Decoder& operator=(const BundledH264Decoder&) = delete;
    [[nodiscard]] std::vector<DecodedFrame> decode(
        std::span<const std::uint8_t> sample, std::int64_t timestamp);
    [[nodiscard]] std::vector<DecodedFrame> drain();
    void flush();

private:
    struct Impl;
    std::unique_ptr<Impl> impl_;
};

} // namespace iPhoneMirror::media
