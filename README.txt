# BepInEx PML Bridge

A bridge to run Pulsar Mod Loader (PML) mods alongside BepInEx mods in *PULSAR: Lost Colony*. Works with a custom PulsarMod Loader fork (v0.12.3.32).

## Features
- **Best of Both Worlds:** Alows players to use mods from Thunderstore/R2Modman and Pulsar Mod Loader at the same time.
- Allows for the Pulsar Mod Loader f5 menu to stiill be functional

## Installation
Install this mode fusing Thunderstore or R2Modman. Install other mods (as desired) from Thunderstore or R2Modman. Place Pulsar Mod Loaders in the default location for those mods (PULSARLostColony/Mods)

### Prerequisites
- BepInEx 5.4.23.2 (via [Thunderstore](https://thunderstore.io/) or manual).
- Run the game once to generate BepInEx folders.

**Structure:**
PULSARLostColony/
├── BepInEx/
│   ├── plugins/
│   │   ├── BepinexPMLBridge.dll
│   │   ├── PMLBridgeLibs/
│   		└── PulsarModLoader.dll
│   │   ├── YourBepInExMod.dll
│   └── ...
├── Mods/
│   └── YourPMLMod.dll
└── ...

## Usage
- Launch via Steam.
- Access PML Mod Menu in-game (e.g., `F5`).
- Check `BepInEx/LogOutput.log` for details.

## Compatibility
- Tested with PML v0.12.3.32 and mods: `Max_Players`, `HUD Warptimer`, `RainbowLight`.
- BepInEx mods tested: `CutsceneSkipper`.
- Thunderstore/R2Modman users: Manually place PML mods in `PULSARLostColony/Mods/`.

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
