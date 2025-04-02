# BepInEx PML Bridge

A compatibility bridge to unite Pulsar Mod Loader (PML) mods and BepInEx mods (including Thunderstore mods) in *PULSAR: Lost Colony*. Run PML mods with their in-game menu or use the bridge standalone for a lightweight setup.

## Features
- **Dual Ecosystem Support:** Seamlessly run PML mods (from `Mods/`) and BepInEx mods (from `BepInEx/plugins/`).
- **Flexible Modes:** Use with native PML for the menu or standalone to bypass PML’s full install.
- **Thunderstore Compatible:** Integrates with Thunderstore’s BepInEx, with optional folder tweaks.

## Installation

### Prerequisites
- **BepInEx:** Install via [Thunderstore Mod Manager](https://thunderstore.io/) or manually (v5.4.23.2 recommended).
- Run *PULSAR: Lost Colony* once to generate BepInEx folders.

### Option 1: With PML Menu (Native PML + Bridge)
For PML mods with the in-game menu + BepInEx mods:
1. **Install PML:**
   - Grab `PulsarModLoader.dll` from [PML’s GitHub](https://github.com/PULSAR-Modders/pulsar-mod-loader).
   - Place it in `BepInEx/plugins/`.
2. **Add the Bridge:**
   - Download `BepinexPMLBridge.dll` from the [Releases](insert-release-link-here) tab.
   - Place it in `BepInEx/plugins/`.
3. **Add Mods:**
   - PML mods (e.g., `LoadingScreenSkipper.dll`) go in `Mods/` (create if missing).
   - BepInEx mods (e.g., Thunderstore mods) go in `BepInEx/plugins/`.

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
   - Download `BepinexPMLBridge.dll` and `PulsarModLoader.dll` from [Releases](insert-release-link-here).
   - Place `BepinexPMLBridge.dll` in `BepInEx/plugins/`.
   - Create `BepInEx/plugins/PMLBridgeLibs/` and add `PulsarModLoader.dll` there.
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

### Thunderstore Notes
- If using Thunderstore Mod Manager, PML mods in `Mods/` may need manual placement, as Thunderstore defaults to `BepInEx/plugins/`.
- Some PML mods with transpilers may fail due to HarmonyX opcode inversions (see Compatibility).

## Usage
- Launch via Steam.
- **With PML Menu:** Access it in-game (e.g., `F5`—check PML docs).
- **Without PML Menu:** Mods run without UI—verify via `BepInEx/LogOutput.log`.
- Log sample:

  [Info :PML Bridge] PML Bridge loaded via BepInEx!
  [Info :Simple Logger] Simple Logger mod loaded via BepInEx!
  [Info :PML] Loaded Mod: Cutscene Skipper...

## Compatibility
- **Tested:** Works with `LoadingScreenSkipper` (PML) and basic BepInEx mods.
- **HarmonyX Issues:** Some PML mods using transpilers may fail due to HarmonyX opcode inversions (e.g., swapped `brtrue`/`brfalse`). Native PML mode is more reliable for these.
- **Thunderstore:** Mods folder (`Mods/`) isn’t standard—manual setup may be needed.
- **Workarounds:** Test mods individually; consider Mest’s HarmonyX fix if available.

## Building
- Open `BepinexPMLBridge.sln` in Visual Studio.
- References: `BepInEx.dll`, `UnityEngine.dll` (from game folder).
- Build to `BepinexPMLBridge.dll`.

## Credits
- Built with Grok (xAI).
- Feedback from the *PULSAR* modding community.

## Issues
- Report bugs or Harmony conflicts at [https://github.com/wildBcat/BepinexPMLBridge/issues].
- HarmonyX opcode inversion may break some PML mods—use native PML mode as needed.
