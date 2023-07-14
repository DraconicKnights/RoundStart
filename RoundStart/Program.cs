using PluginAPI.Core;
using PluginAPI.Core.Attributes;
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

            EventManager.RegisterEvents<Events.SCP079NoiseEvent>(this);
            EventManager.RegisterEvents<Events.SCP914ProcessPlayerEvent>(this);
            EventManager.RegisterEvents<Events.KeycardDoorEvent>(this);
            EventManager.RegisterEvents<Events.WarheadEvent>(this);
        }
    }
}
