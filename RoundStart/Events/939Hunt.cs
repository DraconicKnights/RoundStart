using InventorySystem;
using InventorySystem.Items;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundStart.Events
{
    public class _939Hunt
    {

        Random random = new Random();
        public void _939Event()
        {
            Round.IsLocked = true;

            foreach (Player playerall in PlayerList.GetPlayers())
            {
                playerall.SendBroadcast("Event Round 939 Hunt", 10, Broadcast.BroadcastFlags.Normal);

                playerall.SetRole(RoleTypeId.ClassD, RoleChangeReason.Respawn);

                ItemBase item = ReferenceHub.HostHub.inventory.CreateItemInstance(ItemType.KeycardJanitor, false);

                playerall.ReferenceHub.inventory.ServerAddItem(item.ItemTypeId, 0);
            }

            int index = random.Next(PlayerList.GetPlayers().Count);

            List<IPlayer> targetlist = new List<IPlayer>();

            targetlist = PlayerList.GetPlayers();

            IPlayer playertarget = targetlist[index];

            Player player = (Player)playertarget;

            player.SetRole(RoleTypeId.Scp939, RoleChangeReason.RoundStart);

            player.SendBroadcast("You are 939", 10, Broadcast.BroadcastFlags.Normal);

            Round.IsLocked = false;

        }
    }
}
