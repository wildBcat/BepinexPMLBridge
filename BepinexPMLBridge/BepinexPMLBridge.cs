using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using System.Reflection;

namespace PMLBridge
{
	[BepInPlugin("https://github.com/wildBcat/BepinexPMLBridge/tree/main", "BepinexPMLBridge", "1.0.1")]
	public class BepinexPMLBridge : BaseUnityPlugin
	{
		private static ManualLogSource logger;

		void Awake()
		{
			logger = Logger;
			logger.LogInfo("PML Bridge loaded via BepInEx!");

			// Optional: Load PML mods if PML isn't installed natively
			string pmlPath = Path.Combine(Paths.PluginPath, "PMLBridgeLibs", "PulsarModLoader.dll");
			if (!File.Exists(pmlPath))
			{
				logger.LogInfo("PulsarModLoader.dll not found in PMLBridgeLibs - assuming PML is installed natively.");
			}
			else
			{
				Assembly pmlAssembly = Assembly.LoadFrom(pmlPath);
				logger.LogInfo("Loaded PulsarModLoader.dll into runtime as fallback.");

				Type pulsarModType = pmlAssembly.GetType("PulsarModLoader.PulsarMod");
				if (pulsarModType == null)
				{
					logger.LogError("Could not find PulsarModLoader.PulsarMod type!");
					return;
				}

				string modsDir = Path.Combine(Paths.GameRootPath, "Mods");
				logger.LogInfo($"Checking mods directory: {modsDir}");
				if (!Directory.Exists(modsDir))
				{
					logger.LogWarning("PML Mods folder not found!");
					return;
				}

				var harmony = new Harmony("com.yourname.pmlbridge");
				foreach (string dllPath in Directory.GetFiles(modsDir, "*.dll"))
				{
					try
					{
						Assembly modAssembly = Assembly.LoadFrom(dllPath);
						logger.LogInfo($"Loaded PML mod assembly: {Path.GetFileName(dllPath)}");
						harmony.PatchAll(modAssembly);
						logger.LogInfo($"Applied Harmony patches for {Path.GetFileName(dllPath)}");

						foreach (Type type in modAssembly.GetTypes())
						{
							if (type.IsSubclassOf(pulsarModType))
							{
								logger.LogInfo($"Found PulsarMod type: {type.FullName}");
								object modInstance = Activator.CreateInstance(type);
								logger.LogInfo($"Instantiated mod: {type.FullName}");
							}
						}
					}
					catch (Exception ex)
					{
						logger.LogError($"Failed to load PML mod {Path.GetFileName(dllPath)}: {ex.Message}");
					}
				}
			}

			logger.LogInfo("PML Bridge initialization complete - PML menu should remain active if PML is installed.");
		}
	}
}