#include "Media/SdrBgraConverter.h"

#include <array>
#include <chrono>
#include <cmath>
#include <iostream>
#include <random>
#include <stdexcept>
#include <vector>

void test_sdr_bgra_converter(bool benchmark = false) {
    using namespace iPhoneMirror::media;
    using namespace iPhoneMirror::coremedia;
    std::mt19937 random(0x7b916a);
    for (const auto format : {PixelFormat::Nv12, PixelFormat::P010}) {
        for (const auto range : {ColorRange::Full, ColorRange::Limited, ColorRange::Unspecified}) {
            for (const auto matrix : {MatrixCoefficients::Bt601, MatrixCoefficients::Bt709,
                                      MatrixCoefficients::Bt2020, MatrixCoefficients::Unspecified}) {
                DecodedFrame frame;
                frame.pixel_format = format;
                frame.color.range = range;
                frame.color.matrix = matrix;
                const detail::SdrBgraConverter converter(frame);
                for (const auto width : {1U, 2U, 3U, 4U, 7U, 8U, 9U, 15U, 16U, 17U, 1082U}) {
                    const auto bytes = format == PixelFormat::P010 ? 2U : 1U;
                    std::vector<std::uint8_t> y(width * bytes);
                    std::vector<std::uint8_t> uv(((width + 1U) & ~1U) * bytes);
                    for (auto& v : y) v = static_cast<std::uint8_t>(random());
                    for (auto& v : uv) v = static_cast<std::uint8_t>(random());
                    const auto sample = [bytes](const auto& row, std::size_t x) {
                        if (bytes == 1) return row[x] / 255.0;
                        return (row[x * 2] + (row[x * 2 + 1] << 8U)) / 65535.0;
                    };
                    for (const bool scaled : {false, true}) {
                        const auto output_width = scaled ? (width + 1U) / 2U : width;
                        std::vector<std::uint32_t> map;
                        if (scaled) {
                            for (std::uint32_t x = 0; x < output_width; ++x)
                                map.push_back(x * width / output_width);
                        }
                        std::vector<std::uint8_t> output(output_width * 4U + 32U, 0x7b);
                        converter.row(y.data(), uv.data(), output.data() + 16,
                            output_width, map);
                        for (std::uint32_t x = 0; x < output_width; ++x) {
                            const auto sx = scaled ? map[x] : x;
                            const auto cx = sx & ~1U;
                            const auto expected = detail::convert_yuv_to_sdr(sample(y, sx),
                                sample(uv, cx), sample(uv, cx + 1), frame.color, format);
                            const std::array<double, 3> channels{expected.blue, expected.green, expected.red};
                            for (std::size_t c = 0; c < 3; ++c) {
                                const auto reference = static_cast<int>(std::lround(channels[c] * 255));
                                if (std::abs(static_cast<int>(output[16 + x * 4 + c]) - reference) > 1)
                                    throw std::runtime_error("SIMD BGRA differs from reference by more than one code value");
                            }
                            if (output[16 + x * 4 + 3] != 255)
                                throw std::runtime_error("SIMD BGRA alpha is not opaque");
                        }
                        for (std::size_t i = 0; i < 16; ++i) {
                            if (output[i] != 0x7b || output[output.size() - 1 - i] != 0x7b)
                                throw std::runtime_error("SIMD BGRA wrote beyond the output row");
                        }
                    }
                }
            }
        }
    }
    DecodedFrame frame;
    frame.color.transfer = TransferFunction::Pq;
    if (detail::SdrBgraConverter::supports(frame))
        throw std::runtime_error("HDR unexpectedly selected SDR fast path");
    frame.color.transfer = TransferFunction::Hlg;
    if (detail::SdrBgraConverter::supports(frame))
        throw std::runtime_error("HLG unexpectedly selected SDR fast path");
    frame.color.transfer = TransferFunction::Srgb;
    frame.color.primaries = ColorPrimaries::DisplayP3;
    if (detail::SdrBgraConverter::supports(frame))
        throw std::runtime_error("Display P3 unexpectedly selected SDR fast path");
    std::cout << "SDR BGRA precision, scaling, tail and fallback tests passed\n";

    if (!benchmark) return;
    frame.width = 1082;
    frame.height = 2340;
    frame.color.primaries = ColorPrimaries::Bt709;
    frame.color.range = ColorRange::Full;
    const detail::SdrBgraConverter converter(frame);
    constexpr std::size_t stride = 1088;
    std::vector<std::uint8_t> source(stride * frame.height * 3 / 2, 128);
    std::vector<std::uint8_t> output(static_cast<std::size_t>(frame.width) * frame.height * 4);
    const auto started = std::chrono::steady_clock::now();
    for (unsigned n = 0; n < 60; ++n) {
        for (unsigned y = 0; y < frame.height; ++y)
            converter.row(source.data() + y * stride,
                source.data() + stride * frame.height + (y / 2) * stride,
                output.data() + static_cast<std::size_t>(y) * frame.width * 4, frame.width);
    }
    std::cout << "1082x2340 SDR conversion mean_ms=" <<
        std::chrono::duration<double, std::milli>(std::chrono::steady_clock::now() - started).count() / 60 << '\n';
}
