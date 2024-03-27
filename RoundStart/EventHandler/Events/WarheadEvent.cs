using System;
using System.Collections.Generic;
using PlayerRoles;
using PlayerStatsSystem;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace RoundStart.EventHandler.Events
{
    [Event]
    public class WarheadEvent
    {

        private List<RoleTypeId> _roleTypeIds = new List<RoleTypeId>();

        private Random _random = new Random();

        [PluginEvent(ServerEventType.RoundStart)]
        private void RoundStart()
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
        
        private static Dictionary<string, float> PlayerDamageDic = new Dictionary<string, float>();

        [PluginEvent(ServerEventType.PlayerDamage)]
        private void DamageCount(PlayerDamageEvent args)
        {
            var player = args.Player;
            var target = args.Target;

            if (!player.DoNotTrack) return;
            
            if (target == null && !(Round.IsRoundStarted)) return;

            if (!(args.DamageHandler is AttackerDamageHandler attackerDamageHandler) ||
                attackerDamageHandler.IsFriendlyFire || player.Role != RoleTypeId.ClassD) return;
            if (PlayerDamageDic.ContainsKey(player.UserId))
                PlayerDamageDic[player.UserId] += attackerDamageHandler.Damage;
            else
                PlayerDamageDic.Add(player.UserId, attackerDamageHandler.Damage);

        }

        [PluginEvent(ServerEventType.RoundEnd)]
        public void RoundEnd(RoundEndEvent roundEndEvent)
        {
            foreach (var player in Player.GetPlayers())
            {
                if (player.Team == Team.SCPs && roundEndEvent.LeadingTeam == RoundSummary.LeadingTeam.Anomalies)
                {
                    
                }
            }
        }
    }
}