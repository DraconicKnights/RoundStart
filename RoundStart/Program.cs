using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;
using RoundStart.EventHandler.Events;

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
            EventManager.RegisterEvents<KeycardDoorEvent>(this);
            EventManager.RegisterEvents<WarheadEvent>(this);
            EventManager.RegisterEvents<TeslaGateControl>(this);
            EventManager.RegisterEvents<SCP079ControlEvent>(this);
        }
    }
}
