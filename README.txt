# BepInEx PML Bridge

A bridge to run Pulsar Mod Loader (PML) mods alongside BepInEx mods in *PULSAR: Lost Colony*. Works with a custom PML fork (v0.12.3.32) or as a standalone loader, supporting the PML menu or a lightweight setup.

## Features
- **Dual Compatibility:** Runs PML mods (in `Mods/`) and BepInEx mods (in `BepInEx/plugins/`).
- **Flexible Modes:** Use with forked PML for the menu or bridge-only for simplicity.
- **Harmony 2.9.0.0:** Matches the updated PML fork for stability.

## Installation

### Prerequisites
- BepInEx 5.4.23.2 (via [Thunderstore](https://thunderstore.io/) or manual).
- Run the game once to generate BepInEx folders.

### Option 1: With PML Menu (Forked PML + Bridge)
For PML mods with the menu + BepInEx mods:
1. **Install PML Fork:**
   - Download `PulsarModLoader.dll` (v0.12.3.32) from its [repo releases](insert-pml-release-link-here).
   - Place it in `BepInEx/plugins/`.
2. **Add the Bridge:**
   - Download `BepinexPMLBridge.dll` from the [Releases](https://github.com/wildBcat/BepinexPMLBridge/releases) tab.
   - Place it in `BepInEx/plugins/`.
3. **Add Mods:**
   - PML mods go in `Mods/`.
   - BepInEx mods go in `BepInEx/plugins/`.

**Structure:**
PULSARLostColony/
├── BepInEx/
│   ├── plugins/
│   │   ├── BepinexPMLBridge.dll
│   │   ├── PulsarModLoader.dll
│   │   ├── YourBepInExMod.dll
│   └── ...
├── Mods/
│   └── YourPMLMod.dll
└── ...

### Option 2: Without PML Menu (Bridge Only)
For PML mods without PML’s overhead + BepInEx mods:
1. **Add the Bridge:**
   - Download `BepinexPMLBridge.dll` and `PulsarModLoader.dll` (v0.12.3.32) from the [Releases](https://github.com/wildBcat/BepinexPMLBridge/releases) tab.
   - Place `BepinexPMLBridge.dll` in `BepInEx/plugins/`.
   - Create `BepInEx/plugins/PMLBridgeLibs/` and place `PulsarModLoader.dll` there.
2. **Add Mods:**
   - PML mods go in `Mods/`.
   - BepInEx mods go in `BepInEx/plugins/`.

**Structure:**
PULSARLostColony/
├── BepInEx/
│   ├── plugins/
│   │   ├── BepinexPMLBridge.dll
│   │   ├── PMLBridgeLibs/
│   │   │   └── PulsarModLoader.dll
│   │   ├── YourBepInExMod.dll
│   └── ...
├── Mods/
│   └── YourPMLMod.dll
└── ...

## Usage
- Launch via Steam.
- **With PML Menu:** Access it in-game (e.g., `F5`).
- **Without Menu:** Mods run silently.
- Check `BepInEx/LogOutput.log` for details.

## Compatibility
- Tested with PML v0.12.3.32 and mods: `Max_Players`, `HUD Warptimer`, `RainbowLight`.
- BepInEx mods tested: `SimpleLogger`.
- Thunderstore users: Manually place PML mods in `Mods/`.

## Building
- Open `BepinexPMLBridge.sln` in Visual Studio.
- References:
  - `BepInEx.dll` (from `BepInEx/core/`)
  - `UnityEngine.dll` (from game root)
  - `Harmony.dll` (2.9.0.0 via NuGet or manual)
- Build and copy `BepinexPMLBridge.dll` to `BepInEx/plugins/`.

## Credits
- Built with Grok (xAI).
- Pairs with forked [Pulsar Mod Loader](https://github.com/wildBcat/pulsar-mod-loader-revised).

## Issues
- Report bugs in the [Issues](https://github.com/wildBcat/BepinexPMLBridge/issuese) tab.
