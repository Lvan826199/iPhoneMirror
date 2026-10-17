# Protocol fixtures

The files under `quicktime_video_hack/` are unmodified binary protocol captures
from Daniel Paulus' MIT-licensed `quicktime_video_hack` repository:

https://github.com/danielpaulus/quicktime_video_hack/tree/main/screencapture/packet/fixtures

They are used only as interoperability test vectors. The upstream copyright and
MIT license apply. A verbatim copy is included as
`quicktime_video_hack/LICENSE`. No upstream implementation source is copied
into iPhoneMirror.

`../Avc444Fixture.h` contains SPS, PPS and IDR sets generated from FFmpeg's
synthetic `testsrc2` pattern, without device screenshots or user data:

```
ffmpeg -f lavfi -i testsrc2=size=64x48:rate=30 -frames:v 3 -pix_fmt yuv444p \
  -c:v libx264 -profile:v high444 -tune zerolatency \
  -x264-params keyint=1:bframes=0 -f h264 test-444.h264
```

The first SPS, PPS and IDR NAL units are stored as hexadecimal byte arrays.
The `portrait_*` arrays use the same command with `size=48x64` to verify
landscape → portrait → landscape decoder reconfiguration with new SPS/IDRs.
They exercise actual AVC High 4:4:4 software decoding, flush and timestamp
handling; they are not a claim of real-device resolution support.
