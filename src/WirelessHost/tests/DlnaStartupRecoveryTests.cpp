#include "IpcProtocol.h"
#include <WinSock2.h>
#include <WS2tcpip.h>
#include <Windows.h>
#include <algorithm>
#include <array>
#include <iostream>
#include <string>
#include <vector>

namespace {
struct Fixture {
    SOCKET blocker{INVALID_SOCKET};
    HANDLE pipe{INVALID_HANDLE_VALUE}, stop{}, process{};
    ~Fixture() {
        if (blocker != INVALID_SOCKET) closesocket(blocker);
        if (stop) SetEvent(stop);
        if (process) {
            if (WaitForSingleObject(process, 5000) != WAIT_OBJECT_0) {
                TerminateProcess(process, 1);
                WaitForSingleObject(process, 2000);
            }
            CloseHandle(process);
        }
        if (pipe != INVALID_HANDLE_VALUE) CloseHandle(pipe);
        if (stop) CloseHandle(stop);
        WSACleanup();
    }
};
std::wstring quote(std::wstring_view text) { return L"\"" + std::wstring(text) + L"\""; }
bool finish(HANDLE pipe, OVERLAPPED& op, DWORD& count) {
    if (WaitForSingleObject(op.hEvent, 3000) != WAIT_OBJECT_0) {
        CancelIoEx(pipe, &op);
        GetOverlappedResult(pipe, &op, &count, TRUE);
        return false;
    }
    return GetOverlappedResult(pipe, &op, &count, FALSE) != FALSE;
}
bool read_exact(HANDLE pipe, void* output, std::size_t size) {
    auto* bytes = static_cast<char*>(output);
    while (size) {
        OVERLAPPED op{};
        op.hEvent = CreateEventW(nullptr, TRUE, FALSE, nullptr);
        DWORD count{};
        auto ok = ReadFile(pipe, bytes, static_cast<DWORD>(size), &count, &op) != FALSE;
        if (!ok && GetLastError() == ERROR_IO_PENDING) ok = finish(pipe, op, count);
        CloseHandle(op.hEvent);
        if (!ok || !count) return false;
        bytes += count;
        size -= count;
    }
    return true;
}
bool await_ready(HANDLE pipe, std::uint32_t expected, unsigned& starts) {
    const auto deadline = GetTickCount64() + 12000;
    while (GetTickCount64() < deadline) {
        iPhoneMirror::wireless::MessageHeader header;
        if (!read_exact(pipe, &header, sizeof(header))) continue;
        if (header.magic != iPhoneMirror::wireless::IpcMagic ||
            header.payload_size > iPhoneMirror::wireless::MaxPayloadBytes) return false;
        std::vector<char> body(header.payload_size);
        if (!body.empty() && !read_exact(pipe, body.data(), body.size())) return false;
        if (header.type == iPhoneMirror::wireless::MessageType::Log &&
            std::string_view(body.data(), body.size()).find("wireless_host server_start ") != std::string_view::npos)
            ++starts;
        if (header.type == iPhoneMirror::wireless::MessageType::Ready)
            return header.reserved == expected;
    }
    return false;
}
}

int wmain(int argc, wchar_t** argv) {
    if (argc != 3) return 2;
    WSADATA winsock{};
    if (WSAStartup(MAKEWORD(2, 2), &winsock)) return 2;
    Fixture f;
    f.blocker = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    BOOL exclusive = TRUE;
    setsockopt(f.blocker, SOL_SOCKET, SO_EXCLUSIVEADDRUSE,
        reinterpret_cast<const char*>(&exclusive), sizeof(exclusive));
    sockaddr_in address{AF_INET, 0, {.S_un = {.S_addr = htonl(INADDR_ANY)}}};
    if (bind(f.blocker, reinterpret_cast<const sockaddr*>(&address), sizeof(address)) ||
        listen(f.blocker, 1)) return 3;
    int length = sizeof(address);
    getsockname(f.blocker, reinterpret_cast<sockaddr*>(&address), &length);
    const auto port = ntohs(address.sin_port);
    const auto suffix = std::to_wstring(GetCurrentProcessId()) + L"-" + std::to_wstring(GetTickCount64());
    const auto pipe_name = L"\\\\.\\pipe\\iPhoneMirror-DlnaRecovery-" + suffix;
    const auto stop_name = L"Local\\iPhoneMirror-DlnaRecovery-" + suffix;
    f.pipe = CreateNamedPipeW(pipe_name.c_str(), PIPE_ACCESS_DUPLEX | FILE_FLAG_OVERLAPPED,
        PIPE_TYPE_BYTE | PIPE_READMODE_BYTE | PIPE_WAIT, 1, 65536, 65536, 0, nullptr);
    f.stop = CreateEventW(nullptr, TRUE, FALSE, stop_name.c_str());
    if (f.pipe == INVALID_HANDLE_VALUE || !f.stop) return 4;
    OVERLAPPED connect{};
    connect.hEvent = CreateEventW(nullptr, TRUE, FALSE, nullptr);
    auto connected = ConnectNamedPipe(f.pipe, &connect) != FALSE;
    const auto error = GetLastError();
    auto command = quote(argv[1]) + L" --pipe " + quote(pipe_name) +
        L" --stop-event " + quote(stop_name) + L" --parent-pid " + std::to_wstring(GetCurrentProcessId()) +
        L" --name \"Smoke Test\" --width 1280 --height 720 --fps 30 --mode combined --dlna-port " + std::to_wstring(port) +
        L" --dlna-ssdp-port 0 --library " + quote(argv[2]);
    STARTUPINFOW startup{.cb = sizeof(startup)};
    PROCESS_INFORMATION process{};
    if (!CreateProcessW(argv[1], command.data(), nullptr, nullptr, FALSE,
        CREATE_NO_WINDOW, nullptr, nullptr, &startup, &process)) return 5;
    CloseHandle(process.hThread);
    f.process = process.hProcess;
    DWORD count{};
    connected = connected || error == ERROR_PIPE_CONNECTED ||
        (error == ERROR_IO_PENDING && finish(f.pipe, connect, count));
    CloseHandle(connect.hEvent);
    unsigned server_starts{};
    if (!connected || !await_ready(f.pipe, iPhoneMirror::wireless::ReadyDlnaFailed, server_starts)) {
        std::cerr << "DLNA bind failure was not reported as partial readiness\n";
        return 6;
    }
    closesocket(f.blocker);
    f.blocker = INVALID_SOCKET;
    if (!await_ready(f.pipe, 0, server_starts) || server_starts != 1 ||
        WaitForSingleObject(f.process, 0) != WAIT_TIMEOUT) {
        std::cerr << "DLNA did not recover independently after releasing its port\n";
        return 7;
    }
    const auto client = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    address.sin_addr.s_addr = htonl(INADDR_LOOPBACK);
    const auto opened = ::connect(client, reinterpret_cast<const sockaddr*>(&address), sizeof(address)) == 0;
    const std::string request = "GET /dlna/device.xml HTTP/1.0\r\nHost: localhost\r\n\r\n";
    DWORD timeout = 2000;
    setsockopt(client, SOL_SOCKET, SO_RCVTIMEO, reinterpret_cast<const char*>(&timeout), sizeof(timeout));
    if (opened) send(client, request.data(), static_cast<int>(request.size()), 0);
    std::array<char, 1024> response{};
    const auto received = opened ? recv(client, response.data(), static_cast<int>(response.size()), 0) : 0;
    closesocket(client);
    if (received <= 0 || std::string_view(response.data(), received).find("200 OK") == std::string_view::npos) {
        std::cerr << "Recovered DLNA renderer did not serve its device description\n";
        return 8;
    }
    std::cout << "DLNA bind failure, degraded readiness and independent recovery passed\n";
    return 0;
}
