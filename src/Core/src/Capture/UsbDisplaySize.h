#pragma once

#include <cstdint>
#include <string_view>
#include <utility>

namespace iPhoneMirror::capture {

struct NativeDisplaySize {
    std::uint32_t width;
    std::uint32_t height;
    bool model_known{true};
};

// Panel pixels in portrait orientation, not a guarantee of the USB encoder's
// output size. Keep exact ProductType matches: cellular/storage variants and
// similarly named iPad generations can have different panels.
inline NativeDisplaySize native_display_size(std::wstring_view product_type) noexcept {
    static constexpr std::pair<std::wstring_view, NativeDisplaySize> sizes[] = {
        {L"iPhone13,1", {1080, 2340}},
        {L"iPhone14,4", {1080, 2340}},
        {L"iPhone18,3", {1206, 2622}},
        // iPad Pro 12.9-inch (1st through 6th generation).
        {L"iPad6,7", {2048, 2732}}, {L"iPad6,8", {2048, 2732}},
        {L"iPad7,1", {2048, 2732}}, {L"iPad7,2", {2048, 2732}},
        {L"iPad8,5", {2048, 2732}}, {L"iPad8,6", {2048, 2732}},
        {L"iPad8,7", {2048, 2732}}, {L"iPad8,8", {2048, 2732}},
        {L"iPad8,11", {2048, 2732}}, {L"iPad8,12", {2048, 2732}},
        {L"iPad13,8", {2048, 2732}}, {L"iPad13,9", {2048, 2732}},
        {L"iPad13,10", {2048, 2732}}, {L"iPad13,11", {2048, 2732}},
        {L"iPad14,5", {2048, 2732}}, {L"iPad14,6", {2048, 2732}},
        // iPad Pro 11-inch (1st through 4th generation).
        {L"iPad8,1", {1668, 2388}}, {L"iPad8,2", {1668, 2388}},
        {L"iPad8,3", {1668, 2388}}, {L"iPad8,4", {1668, 2388}},
        {L"iPad8,9", {1668, 2388}}, {L"iPad8,10", {1668, 2388}},
        {L"iPad13,4", {1668, 2388}}, {L"iPad13,5", {1668, 2388}},
        {L"iPad13,6", {1668, 2388}}, {L"iPad13,7", {1668, 2388}},
        {L"iPad14,3", {1668, 2388}}, {L"iPad14,4", {1668, 2388}},
        // iPad Pro M4: 11-inch and 13-inch.
        {L"iPad16,3", {1668, 2420}}, {L"iPad16,4", {1668, 2420}},
        {L"iPad16,5", {2064, 2752}}, {L"iPad16,6", {2064, 2752}},
        // iPad Air 4/5 and 11-inch M2/M3; iPad 10 and A16.
        {L"iPad13,1", {1640, 2360}}, {L"iPad13,2", {1640, 2360}},
        {L"iPad13,16", {1640, 2360}}, {L"iPad13,17", {1640, 2360}},
        {L"iPad14,8", {1640, 2360}}, {L"iPad14,9", {1640, 2360}},
        {L"iPad15,3", {1640, 2360}}, {L"iPad15,4", {1640, 2360}},
        {L"iPad13,18", {1640, 2360}}, {L"iPad13,19", {1640, 2360}},
        {L"iPad15,7", {1640, 2360}}, {L"iPad15,8", {1640, 2360}},
        // iPad Air 13-inch M2/M3.
        {L"iPad14,10", {2048, 2732}}, {L"iPad14,11", {2048, 2732}},
        {L"iPad15,5", {2048, 2732}}, {L"iPad15,6", {2048, 2732}},
        // iPad mini 6 and A17 Pro.
        {L"iPad14,1", {1488, 2266}}, {L"iPad14,2", {1488, 2266}},
        {L"iPad16,1", {1488, 2266}}, {L"iPad16,2", {1488, 2266}},
        // iPad 7/8/9 (10.2-inch), Air 3 / Pro 10.5-inch, mini 5.
        {L"iPad7,11", {1620, 2160}}, {L"iPad7,12", {1620, 2160}},
        {L"iPad11,6", {1620, 2160}}, {L"iPad11,7", {1620, 2160}},
        {L"iPad12,1", {1620, 2160}}, {L"iPad12,2", {1620, 2160}},
        {L"iPad11,3", {1668, 2224}}, {L"iPad11,4", {1668, 2224}},
        {L"iPad7,3", {1668, 2224}}, {L"iPad7,4", {1668, 2224}},
        {L"iPad11,1", {1536, 2048}}, {L"iPad11,2", {1536, 2048}},
    };
    for (const auto& [identifier, size] : sizes)
        if (identifier == product_type) return size;
    // Preserve the conservative negotiation fallback for unknown hardware,
    // but do not describe it as the device's known native resolution.
    if (product_type.starts_with(L"iPad")) return {1640, 2360, false};
    return {1206, 2622, false};
}

} // namespace iPhoneMirror::capture
