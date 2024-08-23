using CustomPlayerEffects;
using PlayerRoles;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace RoundStart.EventHandler.Events
{
    [Event]
    public class SCP939Event
    {
        /*[PluginEvent(ServerEventType.PlayerSpawn)]
        public void OnPlayerSpawn(PlayerSpawnEvent @event)
        {
            if (@event.Player.Role != RoleTypeId.Scp939) return;

            @event.Player.EffectsManager.EnableEffect<Ghostly>(1000, false);
        }*/
    }
}