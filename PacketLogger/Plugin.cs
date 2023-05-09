using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace PacketLogger
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        public static ManualLogSource PluginLog;

        public static ConfigEntry<bool> LogPackets;

        public Plugin()
        {
            PluginLog = Log;
        }

        public override void Load()
        {
            // Plugin startup logic
            var harmony = new Harmony($"com.enovale.{MyPluginInfo.PLUGIN_GUID}");
            harmony.PatchAll(typeof(RequesterPatches));

            LogPackets = Config.Bind("General", nameof(LogPackets), true,
                "Whether or not to print outgoing packets to the console.");
            
            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}