# MOD Bridge

A bridge to run Pulsar Mod Loader (PML) mods alongside BepInEx mods in *PULSAR: Lost Colony*. Works with a custom PulsarMod Loader fork (v0.12.3.32).

## ⚠️ WARNING

This is my first mod and has not been extensively tested. It may produce unexpected results. Use at your own risk. If you experience unintended behavior or issues, please see the [Issues](#issues) section of this README.

## Background
Originally, mods for *PULSAR: Lost Colony* were run using Pulsar Mod Loader. After *PULSAR: Lost Colony* was added to Thunderstore, there was a concern that mods from Pulsar Mod Loader would not be compatible with ones made for Thunderstore using BepIinEx. Something was needed to bridge the two types of mods so they could work together.

## Features

- **Best of Both Worlds:** Allows players to use mods from Thunderstore/R2Modman and Pulsar Mod Loader simultaneously.
- Keeps the Pulsar Mod Loader F5 menu functional.

## Installation

Install this mod using Thunderstore or R2Modman. Install other mods (as desired) from Thunderstore or R2Modman. Place Pulsar Mod Loader files in the default location for those mods (`PULSARLostColony/Mods`).

### Prerequisites

- Use the beta version of *PULSAR: Lost Colony*
  - Go to *PULSAR: Lost Colony* in Steam and click on the settings cog in the upper-right corner
  - Click on "Properties"
  - Click on the "Betas" tab
  - Click the dropdown for "Bet Participation" and select "mono - Mono branch"
 ![Image of where to select the beta of the game](https://media.discordapp.net/attachments/1355206779297861642/1357916378463604929/image.png?ex=67f3ebed&is=67f29a6d&hm=2fc0fd89879c0ad5ffc6f90f409790b4a7ef0a98465e44f514656c7d18b7d083&=&format=webp&quality=lossless&width=1486&height=1061)

- BepInEx 5.4.23.2 (via [Thunderstore](https://thunderstore.io/) or manual install).
- Run the game once to generate BepInEx folders.

**Structure:**

- PULSARLostColony/BepInEx/BepinexPMLBridge.dll
- PULSARLostColony/BepInEx/PMLBridgeLibs/PulsarModLoader.dll
- PULSARLostColony/BepInEx/
- PULSARLostColony/Mods/YourPMLMod.dll
- PULSARLostColony/Mods/YourBepInExMod.dll


## Usage

- Launch the game via Steam.
- Access the PML Mod Menu in-game (e.g., `F5`).
- Check `BepInEx/LogOutput.log` for detailed logs.

## Building

To build the project:

1. Open `BepinexPMLBridge.sln` in Visual Studio.
2. Ensure the following references are correctly configured.

### Required References

| Assembly                 | Source Location                                                                 |
|--------------------------|----------------------------------------------------------------------------------|
| `BepInEx.dll`            | `PULSARLostColony/BepInEx/core/BepInEx.dll`                                     |
| `0Harmony.dll`           | `PULSARLostColony/BepInEx/core/0Harmony.dll` (version 2.2.2.0)                  |
| `PulsarModLoader.dll`    | `PULSARLostColony/BepInEx/plugins/PMLBridgeLibs/PulsarModLoader.dll`           |
| `Assembly-CSharp.dll`    | `PULSARLostColony/PULSAR_LostColony_Data/Managed/Assembly-CSharp.dll`          |
| `UnityEngine.dll`        | `PULSARLostColony/PULSAR_LostColony_Data/Managed/UnityEngine.dll`              |
| `UnityEngine.CoreModule.dll` | `PULSARLostColony/PULSAR_LostColony_Data/Managed/UnityEngine.CoreModule.dll` |
| `Mono.Cecil.dll`         | `packages/Mono.Cecil.0.11.6/lib/net40/Mono.Cecil.dll`                           |
| `Mono.Cecil.Mdb.dll`     | `packages/Mono.Cecil.0.11.6/lib/net40/Mono.Cecil.Mdb.dll`                       |
| `Mono.Cecil.Pdb.dll`     | `packages/Mono.Cecil.0.11.6/lib/net40/Mono.Cecil.Pdb.dll`                       |
| `Mono.Cecil.Rocks.dll`   | `packages/Mono.Cecil.0.11.6/lib/net40/Mono.Cecil.Rocks.dll`                     |

### System Assemblies

Make sure the following .NET Framework assemblies are available (automatically included in most setups targeting .NET Framework 4.7.2):

- `System`
- `System.Core`
- `System.Xml.Linq`
- `System.Data.DataSetExtensions`
- `Microsoft.CSharp`
- `System.Data`
- `System.Net.Http`
- `System.Xml`

3. Build the project.
4. Copy the output `BepinexPMLBridge.dll` into your `PULSARLostColony/BepInEx/plugins/` directory.

## Credits

- Built with Grok (xAI).
- This project includes a file built from a fork of the original PULSAR Mod Loader, developed by the PULSAR Modding Team. It is licensed under the MIT License, which permits reuse and modification with proper attribution.

  - All original work remains © the respective contributors to the PULSAR-Modders repository.

  - This fork may include changes, enhancements, or adaptations specific to my own use or goals. Any substantial changes will be documented clearly.

  - [Forked Pulsar Mod Loader](https://github.com/wildBcat/pulsar-mod-loader-revised)  
  - [Original Pulsar Mod Loader](https://github.com/PULSAR-Modders/pulsar-mod-loader)

## Issues

Report bugs in the [Issues](https://github.com/wildBcat/BepinexPMLBridge/issues) tab.
