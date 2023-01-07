using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using PlayerRoles;
using UnityEngine;
using Random = System.Random;
using InventorySystem.Items.Usables;
using PlayerRoles.PlayableScps.Scp079.Map;
using InventorySystem.Items;
using PluginAPI.Core.Interfaces;
using Scp914;
using MapGeneration.Distributors;
using MapGeneration;
using System.Xml.Linq;
using PluginAPI.Core.Items;
using System.IO;
using CustomPlayerEffects;
using InventorySystem;
using Interactables.Interobjects.DoorUtils;
using PlayerStatsSystem;
using InventorySystem.Items.ThrowableProjectiles;
using System.Reflection;

namespace RoundStart.Events
{
    public class roundStart
    {

        Random random = new Random();

        [PluginEvent(ServerEventType.PlayerUsedItem)]
        public void PlayerUsedItem(IPlayer player, ItemBase itemBase)
        {
            Player player1 = (Player)player;
            if (itemBase.ItemTypeId == ItemType.SCP207)
            {
                int chance = random.Next(1, 10);

                switch (chance)
                {
                    case 5:

                        Vector3 loc = player1.Position;

                        player1.DropEverything();

                        switch (player1.Role)
                        {
                            case RoleTypeId.ClassD:

                                player1.SetRole(RoleTypeId.Scientist, RoleChangeReason.Respawn);

                                break;

                            case RoleTypeId.Scientist:

                                player1.SetRole(RoleTypeId.ClassD, RoleChangeReason.Respawn);

                                break;

                            case RoleTypeId.FacilityGuard:

                                player1.SetRole(RoleTypeId.Scp0492, RoleChangeReason.Respawn);

                                break;

                            case RoleTypeId.NtfPrivate:

                                player1.SetRole(RoleTypeId.FacilityGuard, RoleChangeReason.Respawn);

                                break;

                            case RoleTypeId.NtfSergeant:

                                player1.SetRole(RoleTypeId.NtfPrivate, RoleChangeReason.Respawn);

                                break;

                            case RoleTypeId.ChaosConscript:

                                player1.SetRole(RoleTypeId.ClassD, RoleChangeReason.Respawn);

                                break;
                        }

                        player1.Position = loc;

                        player1.Health = player1.Health + 20;



                        break;
                }
            }

            if (itemBase.ItemTypeId == ItemType.SCP268)
            {
                int chance = random.Next(1, 10);

                switch (chance)
                {
                    case 5:

                        Vector3 loc = player1.Position;

                        player1.DropEverything();

                        switch (player1.Role)
                        {
                            case RoleTypeId.ClassD:

                                player1.SetRole(RoleTypeId.Scp939, RoleChangeReason.Respawn);

                                break;

                            case RoleTypeId.Scientist:

                                player1.SetRole(RoleTypeId.ClassD, RoleChangeReason.Respawn);

                                break;

                            case RoleTypeId.FacilityGuard:

                                player1.SetRole(RoleTypeId.Scp0492, RoleChangeReason.Respawn);

                                break;

                            case RoleTypeId.NtfPrivate:

                                player1.SetRole(RoleTypeId.FacilityGuard, RoleChangeReason.Respawn);

                                break;

                            case RoleTypeId.NtfSergeant:

                                player1.SetRole(RoleTypeId.NtfPrivate, RoleChangeReason.Respawn);

                                break;

                            case RoleTypeId.ChaosConscript:

                                player1.SetRole(RoleTypeId.ClassD, RoleChangeReason.Respawn);

                                break;
                        }

                        player1.Position = loc;

                        break;
                }
            }


        }

        [PluginEvent(ServerEventType.PlayerReport)]
        public void OnChange(IPlayer player, IPlayer target, string reason)
        {
            Player player1 = (Player)player;

            Player player2 = (Player)target;

            player1.SendBroadcast("You have reported the user " + player2.DisplayNickname, 10);

        }

        [PluginEvent(ServerEventType.PlayerJoined)]
        public void onPlayerJoin(IPlayer player)
        {
            PlayerList.AddPlayer(player);
        }

        [PluginEvent(ServerEventType.PlayerLeft)]
        public void onPlayerLeft(IPlayer player)
        {
            PlayerList.RemovePlayer(player);
        }

        [PluginEvent(ServerEventType.RoundStart)]
        public void onStart() 
        {
            Event();
        }

        [PluginEvent(ServerEventType.RoundEnd)]
        public void onRound(RoundSummary.LeadingTeam leading)
        {
            PlayerList.Clear();
        }

        EventCheck eventCheck = new EventCheck(false);

        public void Event()
        {

            if (PlayerList.GetPlayers().Count < 10)
            {
                eventCheck.Active = true;

            }

            if (eventCheck.Active)
            {

                Random random = new Random();

                int eventid = random.Next(10);


                foreach (IPlayer player in PlayerList.GetPlayers())
                {
   


                    switch (eventid)
                    {
                        case 5:
                            _939Hunt _939 = new _939Hunt();
                            _939._939Event();

                            break;


                        case 6:
                            TutorialBattle tutorial = new TutorialBattle();
                            tutorial.TutorialEvent();
                            break;
                            
                            
                    }


                }
            }
        }


    }

}
