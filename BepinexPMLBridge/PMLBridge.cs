using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using System.Reflection;

namespace PMLBridge
{
	[BepInPlugin("com.yourname.pmlbridge", "PML Bridge", "1.0.0")]
	public class PMLBridge : BaseUnityPlugin
	{
		private static ManualLogSource logger;

		void Awake()
		{
			try
			{
				logger = Logger;
				logger.LogInfo("PML Bridge loaded via BepInEx!");

				string pmlPath = Path.Combine(Paths.PluginPath, "PMLBridgeLibs", "PulsarModLoader.dll");
				logger.LogInfo($"Loading PulsarModLoader.dll from: {pmlPath}");
				if (!File.Exists(pmlPath))
				{
					logger.LogError("PulsarModLoader.dll not found in PMLBridgeLibs folder!");
					return;
				}

				Assembly pmlAssembly = Assembly.LoadFrom(pmlPath);
				logger.LogInfo("Loaded PulsarModLoader.dll into runtime");

				// Target HarmonyInjector.InitializeHarmony
				Type injectorType = pmlAssembly.GetType("PulsarModLoader.Injections.HarmonyInjector");
				if (injectorType == null)
				{
					logger.LogError("Could not find PulsarModLoader.Injections.HarmonyInjector type!");
					return;
				}
				logger.LogInfo("Found PulsarModLoader.Injections.HarmonyInjector");

				MethodInfo original = injectorType.GetMethod("InitializeHarmony", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
				if (original == null)
				{
					logger.LogError("Could not find InitializeHarmony method in HarmonyInjector!");
					return;
				}
				logger.LogInfo("Found InitializeHarmony method in HarmonyInjector");

				var harmony = new Harmony("com.yourname.pmlbridge");
				var prefix = typeof(PMLBridge).GetMethod(nameof(DisablePMLInjector), BindingFlags.Static | BindingFlags.NonPublic);
				harmony.Patch(original, new HarmonyMethod(prefix));
				logger.LogInfo("Patched PulsarModLoader.Injections.HarmonyInjector.InitializeHarmony to disable PML initialization");

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
						logger.LogError($"Stack Trace: {ex.StackTrace}");
					}
				}
			}
			catch (Exception ex)
			{
				logger.LogError($"PML Bridge failed to initialize: {ex.Message}");
				logger.LogError($"Stack Trace: {ex.StackTrace}");
			}
		}

		private static bool DisablePMLInjector()
		{
			logger.LogInfo("Blocked PulsarModLoader.Injections.HarmonyInjector.InitializeHarmony from running");
			return false;
		}
	}
}