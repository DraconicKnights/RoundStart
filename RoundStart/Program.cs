using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;
using RoundStart.EventHandler.Events;

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

            EventManager.RegisterEvents<SCP079NoiseEvent>(this);
            EventManager.RegisterEvents<SCP914ProcessPlayerEvent>(this);
            EventManager.RegisterEvents<KeycardDoorEvent>(this);
            EventManager.RegisterEvents<WarheadEvent>(this);
        }
    }
}
