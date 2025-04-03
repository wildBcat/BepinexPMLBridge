using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using System.Reflection;

namespace PMLBridge
{
	[BepInPlugin("com.yourname.pmlbridge", "BepInEx PML Loader", "1.0.2")]
	public class PMLBridge : BaseUnityPlugin
	{
		private static ManualLogSource logger;

		void Awake()
		{
			logger = Logger;
			logger.LogInfo("BepInEx PML Loader starting...");
			var harmonyVersion = typeof(HarmonyLib.Harmony).Assembly.GetName().Version;
			logger.LogInfo($"Harmony version in use: {harmonyVersion}");

			// Check for native PML in BepInEx/plugins/
			string nativePmlPath = Path.Combine(Paths.PluginPath, "PulsarModLoader.dll");
			string bridgePmlPath = Path.Combine(Paths.PluginPath, "PMLBridgeLibs", "PulsarModLoader.dll");

			if (File.Exists(nativePmlPath))
			{
				logger.LogInfo("Native PulsarModLoader.dll found in BepInEx/plugins/ - running in native mode.");
			}
			else if (File.Exists(bridgePmlPath))
			{
				logger.LogInfo("PulsarModLoader.dll found in PMLBridgeLibs/ - loading in bridge mode.");
				try
				{
					Assembly pmlAssembly = Assembly.LoadFrom(bridgePmlPath);
					logger.LogInfo("Loaded PulsarModLoader.dll into runtime.");

					Type pulsarModType = pmlAssembly.GetType("PulsarModLoader.PulsarMod");
					if (pulsarModType == null)
					{
						logger.LogError("Could not find PulsarModLoader.PulsarMod type!");
						return;
					}

					string modsDir = Path.Combine(Paths.GameRootPath, "Mods");
					if (!Directory.Exists(modsDir))
					{
						logger.LogWarning("Mods folder not found!");
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
							foreach (Type type in modAssembly.GetTypes())
							{
								if (type.IsSubclassOf(pulsarModType))
								{
									logger.LogInfo($"Found PulsarMod type: {type.FullName}");
									Activator.CreateInstance(type);
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
				catch (Exception ex)
				{
					logger.LogError($"Failed to load PulsarModLoader.dll: {ex.Message}");
				}
			}
			else
			{
				logger.LogError("PulsarModLoader.dll not found in BepInEx/plugins/ or PMLBridgeLibs/! Install it in either location.");
			}
		}
	}
}