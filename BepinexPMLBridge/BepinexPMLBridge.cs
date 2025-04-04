using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace BepinexPMLBridge
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class PMLBridgePlugin : BaseUnityPlugin
    {
        public const string PluginGuid = "com.wildBcat.bepinex.BepinexPMLBridge";
        public const string PluginName = "BepInEx PML Bridge";
        public const string PluginVersion = "1.1.0";

        // Public accessor for PML mod assemblies
        public static List<Assembly> PMLModAssemblies { get; private set; } = new List<Assembly>();

        private void Awake()
        {
            Logger.LogInfo($"{PluginName} is loading in bridge mode...");
            InitializeBridge();
        }

        private void InitializeBridge()
        {
            string modsPath = Path.Combine(Paths.GameRootPath, "Mods");

            if (!Directory.Exists(modsPath))
            {
                Logger.LogWarning(
                    "Mods directory not found. PML mods will not load until the folder exists."
                );
                return;
            }

            ScanPMLMods(modsPath);

            var harmony = new Harmony(PluginGuid);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            Logger.LogInfo("PML Bridge initialized successfully.");
        }

        private void ScanPMLMods(string modsPath)
        {
            foreach (
                string dllPath in Directory.GetFiles(modsPath, "*.dll", SearchOption.AllDirectories)
            )
            {
                try
                {
                    Assembly modAssembly = Assembly.LoadFrom(dllPath);
                    string modName = Path.GetFileName(dllPath);
                    if (IsPMLMod(modAssembly))
                    {
                        Logger.LogInfo(
                            $"Detected PML mod: {modName} (Assembly: {modAssembly.GetName().Name})"
                        );
                        PMLModAssemblies.Add(modAssembly);
                    }
                    else
                    {
                        Logger.LogInfo(
                            $"Assuming PML mod (loaded by PML): {modName} (Assembly: {modAssembly.GetName().Name})"
                        );
                        PMLModAssemblies.Add(modAssembly);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Failed to scan {Path.GetFileName(dllPath)}: {ex.Message}");
                }
            }
        }

        private bool IsPMLMod(Assembly modAssembly)
        {
            try
            {
                foreach (var type in modAssembly.GetTypes())
                {
                    if (type.Namespace != null && type.Namespace.Contains("PulsarModLoader"))
                        return true;
                    if (type.Name == "Mod" || type.Name.EndsWith("Mod") || type.Name == "Plugin")
                        return true;
                    if (
                        type.GetMethod(
                            "Start",
                            BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static
                        ) != null
                    )
                        return true;
                    if (
                        type.GetMethod(
                            "Main",
                            BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static
                        ) != null
                    )
                        return true;
                }
                return false;
            }
            catch (ReflectionTypeLoadException)
            {
                return true; // Assume it’s a mod if types can’t load (e.g., game dependencies)
            }
        }
    }
}
