using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace RoundStart.EventHandler.Events
{
    public class SCPBots
    {
        [PluginEvent(ServerEventType.RoundStart)]
        private void roundStart()
        {
            var player = UnityEngine.Object.Instantiate(ReferenceHub.HostHub.GetComponent<Player>().GameObject);
        }
    }
}