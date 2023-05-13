using HarmonyLib;
using Server;

namespace PacketLogger
{
    public static class RequesterPatches
    {
        [HarmonyPatch(typeof(HttpApiRequester), nameof(HttpApiRequester.AddRequest))]
        [HarmonyPrefix]
        public static void PacketWrapper(ref HttpApiSchema __0)
        {
            if (Plugin.LogPackets.Value)
                Plugin.PluginLog.LogWarning($"Command Sent to {__0.URL}: {__0.RequestJson}");
        }
    }
}