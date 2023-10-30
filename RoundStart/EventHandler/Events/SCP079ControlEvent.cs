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
                    doors.ServerChangeLock(DoorLockReason.Regular079, true);
                }
            });
        }

        [PluginEvent(ServerEventType.PlayerDeath)]
        private void Scp079Destroyed(PlayerDeathEvent playerDeathEvent)
        {
            Scp079Broadcast();
            MEC.Timing.CallDelayed(10, () =>
            {
                foreach (var players in Player.GetPlayers().Where(players => players.Role == RoleTypeId.Scp079))
                {
                    foreach (var doors in DoorVariant.AllDoors)
                    {
                        if (!(doors is PryableDoor pryableDoor)) continue;

                        if (!pryableDoor.IsInZone(FacilityZone.Entrance)) continue;

                        doors.NetworkTargetState = true;
                        doors.ServerChangeLock(DoorLockReason.Regular079, false);
                    }
                }
            });
        }

        private void Scp079Broadcast()
        {
            foreach (var players in Player.GetPlayers())
            {
                players.SendBroadcast("SCP 079 has been Destroyed, All Control doors are now open", 10, Broadcast.BroadcastFlags.Normal);
            }
        }
    }
}