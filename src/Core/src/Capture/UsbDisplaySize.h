#pragma once

#include <cstdint>
#include <string_view>
#include "../../../Shared/Devices/AppleDisplayCatalog.generated.h"

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
    if (const auto* display = devices::find_apple_display(product_type))
        return {display->width, display->height, true};
    // Preserve the conservative negotiation fallback for unknown hardware,
    // but do not describe it as the device's known native resolution.
    if (product_type.starts_with(L"iPad")) return {1640, 2360, false};
    return {1206, 2622, false};
}

} // namespace iPhoneMirror::capture
