using PluginAPI.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginAPI.Enums;
using PluginAPI.Core.Interfaces;
using PlayerStatsSystem;
using PluginAPI.Core;
using PlayerRoles;
using System.Collections;
using InventorySystem.Items;
using InventorySystem;
using PluginAPI.Core.Items;
using Scp914;
using System.Numerics;

namespace RoundStart.Events
{
    public class SCP914ProcessPlayerEvent
    {

        Random random = new Random();


        #region SCP914 Player

        [PluginEvent(ServerEventType.Scp914ProcessPlayer)]
        void onProcesPlayer(IPlayer player, Scp914KnobSetting setting, UnityEngine.Vector3 vector)
        {

            Config config = new Config();

            if (!config.SCP914ProcessPlayerEvent)
                return;

            Player player1 = ( Player)player;


         

            switch (setting)
            {
                case Scp914KnobSetting.Rough:
                    scp914ClassSelect(player1);

                    break;

                case Scp914KnobSetting.Coarse:
                    scp914CourseSelect(player1);
                    break;

                case Scp914KnobSetting.OneToOne:


                    break;
                case Scp914KnobSetting.Fine:


                    break;
                case Scp914KnobSetting.VeryFine:
                    break;

            }


            player1.Position = vector;




        }


        private void scp914CourseSelect(Player player)
        {
            int id = random.Next(10);

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

        private void scp914ClassSelect(Player player)
        {

            if (player.Role == RoleTypeId.ClassD)
                player.SetRole(RoleTypeId.Scp939, RoleChangeReason.RemoteAdmin);

            if (player.Role == RoleTypeId.Scientist)
                player.SetRole(RoleTypeId.ClassD, RoleChangeReason.RemoteAdmin);

            if (player.Role == RoleTypeId.FacilityGuard)
                player.SetRole(RoleTypeId.Scp0492, RoleChangeReason.RemoteAdmin);

            if (player.Role == RoleTypeId.NtfPrivate)
                player.SetRole(RoleTypeId.FacilityGuard, RoleChangeReason.RemoteAdmin);

            if (player.Role == RoleTypeId.NtfSergeant)
                player.SetRole(RoleTypeId.NtfPrivate, RoleChangeReason.RemoteAdmin);

            if (player.Role == RoleTypeId.NtfSpecialist)
                player.SetRole(RoleTypeId.NtfPrivate, RoleChangeReason.RemoteAdmin);

            if (player.Role == RoleTypeId.NtfCaptain)
                player.SetRole(RoleTypeId.NtfSergeant, RoleChangeReason.RemoteAdmin);

            if (player.Role == RoleTypeId.ChaosConscript)
                player.SetRole(RoleTypeId.ClassD, RoleChangeReason.RemoteAdmin);

            if (player.Role == RoleTypeId.ChaosRifleman)
                player.SetRole(RoleTypeId.ChaosConscript, RoleChangeReason.RemoteAdmin);

            if (player.Role == RoleTypeId.ChaosRepressor)
                player.SetRole(RoleTypeId.ChaosRifleman, RoleChangeReason.RemoteAdmin);

            if (player.Role == RoleTypeId.ChaosMarauder)
                player.SetRole(RoleTypeId.ChaosRepressor, RoleChangeReason.RemoteAdmin);



        }

    }

    #endregion SCP914 Player

}
