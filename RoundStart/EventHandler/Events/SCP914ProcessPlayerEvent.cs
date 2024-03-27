using System;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using Scp914;
using Random = System.Random;

namespace RoundStart.EventHandler.Events
{
    [Event]
    public class Scp914ProcessPlayerEvent
    {
        private Random _random = new Random();

        #region SCP914 Player

        [PluginEvent(ServerEventType.Scp914ProcessPlayer)]
        private void OnProcesPlayer(Player player, Scp914KnobSetting setting, UnityEngine.Vector3 vector)
        {

            if (new Config().Scp914ProcessPlayerEvent != true) return;

            var player1 = ( Player)player;
            
            switch (setting)
            {
                case Scp914KnobSetting.Rough:
                    Scp914ClassSelect(player1);

                    break;

                case Scp914KnobSetting.Coarse:
                    Scp914CourseSelect(player1);
                    break;

                case Scp914KnobSetting.OneToOne:


                    break;
                case Scp914KnobSetting.Fine:


                    break;
                case Scp914KnobSetting.VeryFine:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(setting), setting, null);
            }


            player1.Position = vector;




        }
        
        private void Scp914CourseSelect(Player player)
        {
            var id = _random.Next(10);

            switch (id)
            {
                case 0:
                    player.SetRole(RoleTypeId.Scp0492, RoleChangeReason.RemoteAdmin);
                    break;
                case 1:
                    player.SetRole(RoleTypeId.FacilityGuard, RoleChangeReason.RemoteAdmin);
                    break;
                case 2:
                    player.ClearInventory(true, true);
                    break;
                case 3:
                    player.Kill();
                    break;
                case 4:
                    player.Health = 40;
                    break;
                case 5:
                    player.ArtificialHealth = 10;
                    break;
                case 6:
                    player.Health = -10;
                    break;
                
                }
        }

        private void Scp914ClassSelect(Player player)
        {
            switch (player.Role)
            {
                case RoleTypeId.ClassD:
                    player.SetRole(RoleTypeId.None);
                    break;
                case RoleTypeId.Scientist:
                    player.SetRole(RoleTypeId.ClassD);
                    break;
                case RoleTypeId.FacilityGuard:
                    player.SetRole(RoleTypeId.Scientist);
                    break;
                case RoleTypeId.ChaosConscript:
                    player.SetRole(RoleTypeId.ClassD);
                    break;
                    
            }

        }

        private void Scp914VeryFine(Player player)
        {
            var allroles = (RoleTypeId[])Enum.GetValues(typeof(RoleTypeId));
            
            int id = _random.Next(allroles.Length);

            var role = allroles[id];
            
            if (role == RoleTypeId.Filmmaker | role == RoleTypeId.Overwatch)
                return;
            
            player.SetRole(role);
        }

    }

    #endregion SCP914 Player

}
