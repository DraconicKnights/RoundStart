using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace RoundStart.Events
{
    public class WarheadEvent
    {

        private List<RoleTypeId> _roleTypeIds = new List<RoleTypeId>();

        private Random _random = new Random();

        [PluginEvent(ServerEventType.RoundStart)]
        private void roundStart()
        {
            var allroles = (RoleTypeId[])Enum.GetValues(typeof(RoleTypeId));
            
            if (!_roleTypeIds.IsEmpty())
                return;
            
            foreach (var role in allroles)
            {
                if (role == RoleTypeId.ClassD || role == RoleTypeId.FacilityGuard || role == RoleTypeId.Scientist)
                    _roleTypeIds.Add(role);
                return;
            }
        }

        [PluginEvent(ServerEventType.PlayerJoined)]
        private void PlayerJoin(PlayerJoinedEvent playerJoinedEvent)
        {
            if (!Round.IsRoundStarted)
                return;

            if (!(Round.Duration.TotalSeconds < 30))
                return;
            
            int id = _random.Next(_roleTypeIds.Count);

            Player player = playerJoinedEvent.Player;
            
            player.SetRole(_roleTypeIds[id], RoleChangeReason.LateJoin);
        }
    }
}