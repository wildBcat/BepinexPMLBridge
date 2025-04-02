# BepInEx PML Bridge

A lightweight bridge to run Pulsar Mod Loader (PML) mods alongside BepInEx mods in *PULSAR: Lost Colony*. Choose between keeping the PML menu with a native PML install or replacing PML entirely with this bridge.

## Features
- **Dual Compatibility:** Supports PML mods (in `Mods/`) and BepInEx mods (in `BepInEx/plugins/`).
- **Flexible Setup:** Use with native PML for the in-game menu, or standalone to skip PML’s overhead.
- **Thunderstore Ready:** Works with Thunderstore’s BepInEx installs for seamless modding.

## Installation

### Prerequisites
- **BepInEx:** Install via [Thunderstore Mod Manager](https://thunderstore.io/) or manually (v5.4.23.2 recommended).
- Run the game once to generate BepInEx folders.

### Option 1: With PML Menu (Native PML + Bridge)
For PML mods with the in-game menu + BepInEx mods:
1. **Install PML:**
   - Download `PulsarModLoader.dll` from [PML’s official source](https://github.com/PULSAR-Modders/pulsar-mod-loader).
   - Place it in `BepInEx/plugins/`.
2. **Add the Bridge:**
   - Download `BepinexPMLBridge.dll` from the [Releases](insert-release-link-here) tab.
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
For PML mods without PML’s overhead + BepInEx mods:
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
- Launch the game via Steam.
- **With PML Menu:** Access the PML menu in-game (check PML docs for keybind, e.g., `F5`).
- **Without PML Menu:** Mods run silently—no menu, but functionality (e.g., cutscene skipping) works.
- Check `BepInEx/LogOutput.log` for load confirmation.

## Compatibility
- Tested with `LoadingScreenSkipper` (PML) and simple BepInEx mods.
- Complex PML mods needing the menu require Option 1.
- Harmony conflicts between mods are possible—test your setup.

## Building
- Open `BepinexPMLBridge.sln` in Visual Studio.
- References: `BepInEx.dll`, `UnityEngine.dll` (from game folder).
- Build and copy `BepinexPMLBridge.dll` to `BepInEx/plugins/`.

## Credits
- Built with help from Grok (xAI).
- For *PULSAR: Lost Colony* modders and players.

## Issues
- Report bugs or mod conflicts in the [Issues](insert-issues-link-here) tab.