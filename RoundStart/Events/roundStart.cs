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
using RoundStart.Events.Staff;

namespace RoundStart.Events
{
    public class roundStart
    {

        [PluginEvent(ServerEventType.PlayerReport)]
        public void OnChange(IPlayer player, IPlayer target, string reason)
        {
            Player player1 = (Player)player;

            Player player2 = (Player)target;

            player1.SendBroadcast("You have reported the user " + player2.DisplayNickname, 10);

            foreach (Player staff in StaffList.GetPlayers())
            {
                staff.SendBroadcast("A report has been made", 10, Broadcast.BroadcastFlags.AdminChat);
            }

        }

        [PluginEvent(ServerEventType.PlayerJoined)] 
        public void OnJoin(IPlayer player)
        {
            Player player1 = (Player)player;

            if (player1.RemoteAdminAccess && player1.UserId == Config.staff_id)
            {
                StaffList.addStaff(player);
            }
        }

        [PluginEvent(ServerEventType.PlayerLeft)]
        public void OnLeft(IPlayer player)
        {
            Player player1 = (Player)player;

            if (player1.RemoteAdminAccess && player1.UserId == Config.staff_id)
            {
                StaffList.removeStaff(player);
            }
        }

    }

}
