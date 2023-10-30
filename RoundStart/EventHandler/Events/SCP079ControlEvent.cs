using System.Linq;
using Interactables.Interobjects;
using Interactables.Interobjects.DoorUtils;
using MapGeneration;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace RoundStart.EventHandler.Events
{
    public class SCP079ControlEvent
    {
        [PluginEvent(ServerEventType.RoundStart)]
        private void Scp079Spawn()
        {
            MEC.Timing.CallDelayed(5, () =>
            {
                foreach (var doors in Player.GetPlayers().Where(players => players.Role == RoleTypeId.Scp079)
                             .SelectMany(players => DoorVariant.AllDoors))
                {
                    if (!(doors is PryableDoor pryableDoor)) continue;

                    if (!pryableDoor.IsInZone(FacilityZone.Entrance)) continue;

                    doors.NetworkTargetState = false;
                    doors.ServerChangeLock(DoorLockReason.AdminCommand, true);
                    
                    Scp079BroadcastLockdown();
                }
                
            });
        }

        [PluginEvent(ServerEventType.PlayerDeath)]
        private void Scp079Destroyed(PlayerDeathEvent playerDeathEvent)
        {
            if (playerDeathEvent.Player.Role != RoleTypeId.Scp079) return;
            
            Scp079BroadcastEscape();
            MEC.Timing.CallDelayed(10, () =>
            {
                foreach (var doors in DoorVariant.AllDoors)
                {
                    if (!(doors is PryableDoor pryableDoor)) continue;

                    if (!pryableDoor.IsInZone(FacilityZone.Entrance)) continue;

                    doors.NetworkTargetState = true;
                    doors.ServerChangeLock(DoorLockReason.AdminCommand, false);
                }
                
            });
        }
        
        [PluginEvent(ServerEventType.PlayerLeft)]
        private void Scp079Leave(PlayerLeftEvent playerLeftEvent)
        {
            if (playerLeftEvent.Player.Role != RoleTypeId.Scp079) return;
            
            Scp079BroadcastEscape();
            MEC.Timing.CallDelayed(10, () =>
            {
                foreach (var doors in DoorVariant.AllDoors)
                {
                    if (!(doors is PryableDoor pryableDoor)) continue;

                    if (!pryableDoor.IsInZone(FacilityZone.Entrance)) continue;

                    doors.NetworkTargetState = true;
                    doors.ServerChangeLock(DoorLockReason.AdminCommand, false);
                }
                
            });
        }
        
        [PluginEvent(ServerEventType.PlayerChangeRole)]
        private void Scp079Leave(PlayerChangeRoleEvent playerChangeRoleEvent)
        {
            if (playerChangeRoleEvent.OldRole.RoleTypeId != RoleTypeId.Scp079) return;
            
            Scp079BroadcastEscape();
            MEC.Timing.CallDelayed(10, () =>
            {
                foreach (var doors in DoorVariant.AllDoors)
                {
                    if (!(doors is PryableDoor pryableDoor)) continue;

                    if (!pryableDoor.IsInZone(FacilityZone.Entrance)) continue;

                    doors.NetworkTargetState = true;
                    doors.ServerChangeLock(DoorLockReason.AdminCommand, false);
                }
                
            });
        }
        private void Scp079BroadcastEscape()
        {
            foreach (var players in Player.GetPlayers())
            {
                players.SendBroadcast("SCP 079 has been Destroyed, All Control doors are now open", 10, Broadcast.BroadcastFlags.Normal);
            }
        }
        
        private void Scp079BroadcastLockdown()
        {
            foreach (var players in Player.GetPlayers())
            {
                players.SendBroadcast("SCP079 has locked down the facility and must be deactivated in order to escape", 10, Broadcast.BroadcastFlags.Normal);
            }
        }
    }
}