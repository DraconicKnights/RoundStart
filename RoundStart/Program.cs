using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Core.Factories;
using PluginAPI.Events;

namespace RoundStart
{
    public class Plugin
    {
        [PluginConfig]
        public static Config config;

        [PluginEntryPoint("Round Start", "1.0", "Round Start Plugin", "Draconic")]
        public void OnPluginStart()
        {
            Log.Info("$Plugin is loading");

            EventManager.RegisterEvents<Events.roundStart>(this);
        }
    }
}
