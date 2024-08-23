using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;
using Scp914;
using Random = System.Random;

namespace RoundStart.EventHandler.Events
{
    [Event]
    public class Scp914ProcessPlayerEvent
    {
        private Random _random = new Random();

        [PluginEvent(ServerEventType.Scp914ProcessPlayer)]
        private void OnProcessPlayer(Player player, Scp914KnobSetting setting, UnityEngine.Vector3 vector)
        {
            if (!(new Config().Scp914ProcessPlayerEvent)) return;
            
        }

        [PluginEvent(ServerEventType.Scp914UpgradeInventory)]
        private void OnProcessPlayerInventory(Scp914UpgradeInventoryEvent @event)
        {
            
        }
    }

}
