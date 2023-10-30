using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;
using RoundStart.EventHandler.Events;
using Scp914ProcessPlayerEvent = RoundStart.EventHandler.Events.Scp914ProcessPlayerEvent;

namespace RoundStart
{
    public class Plugin
    {
        [PluginConfig]
        public static Config Config;

        [PluginEntryPoint("Round Start", "1.0", "Round Start Plugin", "Draconic")]
        public void OnPluginStart()
        {
            Log.Info("$Plugin is loading");

            EventManager.RegisterEvents<Scp079NoiseEvent>(this);
            EventManager.RegisterEvents<Scp914ProcessPlayerEvent>(this);
            EventManager.RegisterEvents<KeycardDoorEvent>(this);
            EventManager.RegisterEvents<WarheadEvent>(this);
        }
    }
}
