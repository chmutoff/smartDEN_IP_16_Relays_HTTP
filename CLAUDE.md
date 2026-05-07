# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build / Run

This is a C# WinForms app targeting **.NET Framework 4.0 Client Profile**, **x86**, originally created with Visual Studio 2010. There is no test project, no package manager, no CI, and no lint config.

```powershell
# Build (Developer PowerShell or any shell with MSBuild on PATH)
msbuild smartDEN_IP_16_Relays_HTTP.sln /p:Configuration=Release /p:Platform=x86
msbuild smartDEN_IP_16_Relays_HTTP.sln /p:Configuration=Debug   /p:Platform=x86

# Run
.\smartDEN_IP_16_Relays_HTTP\bin\Debug\smartDEN_IP_16_Relays_HTTP.exe
```

`settings.ini` is copied next to the exe on build (`CopyToOutputDirectory=PreserveNewest`); the app reads/writes it from `./settings.ini` relative to the working directory, so launch from the output folder or it will silently fall back to defaults.

UI work usually requires the WinForms designer in Visual Studio — `Form1.Designer.cs` is auto-generated and shouldn't be hand-edited for layout changes.

## Architecture

The whole app is essentially [Form1.cs](smartDEN_IP_16_Relays_HTTP/Form1.cs) plus a thin INI helper. Two non-obvious pieces of behavior are spread across multiple methods and worth understanding before changing anything:

### Device protocol

Talks to a **smartDEN IP-16R** relay board over HTTP. Every interaction goes through `GetStateRequest(parameter)` which builds:

```
http://{IP}:{Port}/current_state.xml?pw={Password}{parameter}
```

`parameter` is either empty (poll state) or `&RelayN=0|1` (toggle a relay). Responses are XML scraped with `IndexOf` / `Substring` — there is no XML parser. Three response shapes are detected: `<CurrentState>` (success), `<LoginKey>` (wrong password), and a redirect to `/login_info.xml` (treated as "Already Logged" — another admin holds the session). A 3-second `Timer` re-polls by calling `refreshButton.PerformClick()` so the UI stays in sync with external changes.

### Two-way checkbox sync, with a reentrancy guard

There are 24 relay CheckBoxes: `relay1`–`relay16` (the real device relays) and `relay101`–`relay108` (mirror controls for relays 1–8 that act as inverted toggles — clicking `relay10N` sends `RelayN=!relayN.Checked`).

`updateStates(xmlResponse)` parses the device state and writes it back into `Checked`. That assignment fires `CheckedChanged`, which would normally send another HTTP request — creating an infinite loop. The `userClick` bool gates this: every `relayN_CheckedChanged` handler is wrapped in `if (userClick == true)`, and `updateStates` sets `userClick = false` while it mutates the UI, then `true` again. **Any new programmatic change to a relay CheckBox must rely on this guard or set it manually**, or you'll fire spurious requests.

Hotkey-driven changes use a parallel guard: `WndProc` sets `hotKeyLock = true` for the duration of a hotkey handler so a held-down key (which Windows repeats via `WM_HOTKEY`) doesn't queue overlapping HTTP calls.

### Domain-specific relay coupling

The handlers encode physical wiring assumptions, not generic relay control:

- **Relays 9–16 are mutually exclusive.** `disableOtherHalf(clickedRelayId)` turns off every other relay in 9–16 when one is enabled. The hotkey-driven cycler (`lastActiveRelayId` with `((x % 8 + 8) % 8) + 8` modulo, see `case 3` / `case 4` in `WndProc`) walks through this group.
- **Turning on relay 4 also turns on relays 1, 2, 3** ([Form1.cs:361-366](smartDEN_IP_16_Relays_HTTP/Form1.cs:361)). Hotkeys 8 and 9 (apostrophe / tilde) replicate this as a "turn on 1+2+3+4" combo.
- Hotkeys 1 and 2 (F9 / F10) are hardcoded to **relay 6 off / on** — the keys are general but the actions are not.
- Hotkeys 5/6/7 (comma/period/semicolon) toggle relays 1/2/3.

Hotkeys are registered via `user32!RegisterHotKey` (P/Invoke) in the constructor and only fire while the app `isConnected`. They're **global** — they fire even when the app is in the background.

### Configuration

`settings.ini` has `[Network]` (IP/Port/Password) and `[Buttons]` (display label per relay). [INIFile.cs](smartDEN_IP_16_Relays_HTTP/INIFile.cs) is a P/Invoke wrapper around `kernel32!GetPrivateProfileString` / `WritePrivateProfileString` — note these are the legacy Win32 INI APIs and have a 255-char buffer (`StringBuilder(255)`) plus the usual quirks (UTF-16 quirks, BOM handling). Currently only `IniReadValue` is called; `IniWriteValue` exists but is unused, so settings are read at startup and never persisted back.
