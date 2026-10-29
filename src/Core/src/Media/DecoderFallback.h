#pragma once

#include <exception>

namespace iPhoneMirror::media::detail {

// Recovery must advance to the next candidate or return false at exhaustion.
// Both configuration and first-input failures belong to the same chain.
template<class Decode, class Recover>
auto decode_with_fallback(Decode decode, Recover recover) -> decltype(decode()) {
    for (;;) {
        try { return decode(); }
        catch (const std::exception& error) {
            if (!recover(error)) throw;
        }
    }
}

} // namespace iPhoneMirror::media::detail
