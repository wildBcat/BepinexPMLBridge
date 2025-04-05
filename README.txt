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

Building
--------

To build the project:

1.  Open `BepinexPMLBridge.sln` in Visual Studio.

2.  Ensure the following references are correctly configured:

### Required References

| Assembly | Source Location |
| --- | --- |
| `BepInEx.dll` | `PULSARLostColony/BepInEx/core/BepInEx.dll` |
| `0Harmony.dll` | `PULSARLostColony/BepInEx/core/0Harmony.dll` (version 2.2.2.0) |
| `PulsarModLoader.dll` | `PULSARLostColony/BepInEx/plugins/PMLBridgeLibs/PulsarModLoader.dll` (version 0.12.3.31) |
| `Assembly-CSharp.dll` | `PULSARLostColony/PULSAR_LostColony_Data/Managed/Assembly-CSharp.dll` |
| `UnityEngine.dll` | `PULSARLostColony/PULSAR_LostColony_Data/Managed/UnityEngine.dll` |
| `UnityEngine.CoreModule.dll` | `PULSARLostColony/PULSAR_LostColony_Data/Managed/UnityEngine.CoreModule.dll` |
| `Mono.Cecil.dll` | `packages/Mono.Cecil.0.11.6/lib/net40/Mono.Cecil.dll` |
| `Mono.Cecil.Mdb.dll` | `packages/Mono.Cecil.0.11.6/lib/net40/Mono.Cecil.Mdb.dll` |
| `Mono.Cecil.Pdb.dll` | `packages/Mono.Cecil.0.11.6/lib/net40/Mono.Cecil.Pdb.dll` |
| `Mono.Cecil.Rocks.dll` | `packages/Mono.Cecil.0.11.6/lib/net40/Mono.Cecil.Rocks.dll` |

### System Assemblies

Also ensure that the following .NET Framework assemblies are available (automatically included in most setups targeting .NET Framework 4.7.2):

-   `System`

-   `System.Core`

-   `System.Xml.Linq`

-   `System.Data.DataSetExtensions`

-   `Microsoft.CSharp`

-   `System.Data`

-   `System.Net.Http`

-   `System.Xml`

1.  Build the project.

2.  Copy the output `BepinexPMLBridge.dll` into your `PULSARLostColony/BepInEx/plugins/` directory.

## Credits
- Built with Grok (xAI).

- This project includes a file built from a fork of the original PULSAR Mod Loader, developed by the PULSAR Modding Team. It is licensed under the MIT License, which permits reuse and modification with proper attribution.

All original work remains © the respective contributors to the PULSAR-Modders repository.

This fork may include changes, enhancements, or adaptations specific to my own use or goals. Any substantial changes will be documented clearly.
[Forked Pulsar Mod Loader](https://github.com/wildBcat/pulsar-mod-loader-revised).
[Original Pulsar Mod Loader] (https://github.com/PULSAR-Modders/pulsar-mod-loader).

## Issues
- Report bugs in the [Issues](https://github.com/wildBcat/BepinexPMLBridge/issuese) tab.
