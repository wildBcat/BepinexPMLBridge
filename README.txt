# BepInEx PML Bridge

A compatibility bridge for *PULSAR: Lost Colony* that unites Pulsar Mod Loader (PML) mods and BepInEx mods. Run PML mods with their in-game menu or go lightweight without it, all while supporting Thunderstore-style BepInEx mods.

## Features
- **Dual Ecosystem:** Load PML mods (in `Mods/`) and BepInEx mods (in `BepInEx/plugins/`) together.
- **Flexible Modes:** Keep the PML menu with native PML, or replace PML with this bridge for simplicity.
- **Harmony Stability:** Uses Harmony 2.2.2 (game’s version) for consistent patching across BepInEx and PML.

## Installation

### Prerequisites
- **BepInEx:** Install via [Thunderstore Mod Manager](https://thunderstore.io/) or manually (v5.4.23.2 recommended).
- Run the game once to generate BepInEx folders.

### Option 1: With PML Menu (Native PML + Bridge)
For PML mods with the in-game menu (e.g., `F5`) plus BepInEx mods:
1. **Install PML:**
   - Download `PulsarModLoader.dll` from [PML’s GitHub](https://github.com/PULSAR-Modders/pulsar-mod-loader).
   - Place it in `BepInEx/plugins/`.
2. **Add the Bridge:**
   - Get `BepinexPMLBridge.dll` from the [Releases](insert-release-link-here) tab.
   - Place it in `BepInEx/plugins/`.
3. **Add Mods:**
   - PML mods (e.g., `LoadingScreenSkipper.dll`) go in `Mods/` (create if missing).
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
For PML mods without PML’s overhead plus BepInEx mods:
1. **Add the Bridge:**
   - Download `BepinexPMLBridge.dll` and `PulsarModLoader.dll` from the [Releases](insert-release-link-here) tab.
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
- **With PML Menu:** Access it in-game (e.g., `F5`—see PML docs for keybind).
- **Without PML Menu:** Mods run silently—no menu, but functionality remains (e.g., cutscene skipping).
- Check `BepInEx/LogOutput.log` for load details.

## Compatibility
- **Tested:** PML v0.12.3.31 with `LoadingScreenSkipper` (cutscenes skip, menu works) and BepInEx 5.4.23.2.
- **Harmony:** Uses 2.2.2 from `PULSAR_LostColony_Data/Managed/` to match the game and avoid HarmonyX opcode conflicts (e.g., transpiler issues).
- **PML Notes:** Logs `[PML] Failed to patch by sequence` for RPC/chat patches. Normal and harmless with simple mods like `LoadingScreenSkipper`. Test multiplayer or chat mods for potential impact.
- **Thunderstore:** BepInEx mods load seamlessly. PML mods in `Mods/` need manual placement (Thunderstore doesn’t auto-support this folder).

## Building
- Open `BepinexPMLBridge.sln` in Visual Studio.
- References:
  - `BepInEx.dll` (from `BepInEx/core/`)
  - `UnityEngine.dll` (from game root)
  - `Harmony.dll` (2.2.2 from `PULSAR_LostColony_Data/Managed/`)
- Build and copy `BepinexPMLBridge.dll` to `BepInEx/plugins/`.

## Credits
- Built with Grok (xAI).
- For *PULSAR: Lost Colony* modders and players.

## Issues
- Report bugs, mod conflicts, or Thunderstore quirks in the [Issues](https://github.com/wildBcat/BepinexPMLBridge/issues) tab.
