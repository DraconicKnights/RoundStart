using CommandSystem;
using Interactables.Interobjects;
using Interactables.Interobjects.DoorUtils;
using InventorySystem;
using InventorySystem.Items;
using InventorySystem.Items.Firearms;
using MapGeneration;
using PluginAPI.Core;
using PluginAPI.Core.Zones;
using RoundStart.Events.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundStart.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Upgrade : ICommand, IUsageProvider
    {

        Random random = new Random();
        public string Command => "upgrade";

        public string[] Aliases => null;

        public string Description => "Upgrade the current equipped item";

        public string[] Usage => null;

        List<DoorVariant> doorslist = new List<DoorVariant>();

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            if (!sender.CheckPermission(PlayerPermissions.GivingItems))
            {
                response = "You don't have permission to use this command";
                return true;
            }


            foreach (Player player in Player.GetPlayers())
            {

                int id = random.Next(Itemlist.GetItemTypes().Count);

                ItemType item = Itemlist.GetItemTypes()[id];

                player.ClearInventory();

                player.SetRole(PlayerRoles.RoleTypeId.ClassD, PlayerRoles.RoleChangeReason.RemoteAdmin);
                player.AddAmmo(ItemType.Ammo44cal, 20);
                player.AddAmmo(ItemType.Ammo12gauge, 20);
                player.AddAmmo(ItemType.Ammo556x45, 20);
                player.AddAmmo(ItemType.Ammo762x39, 20);
                player.AddAmmo(ItemType.Ammo9x19, 20);

                if (doorslist.IsEmpty())
                {
                    foreach (DoorVariant doorVariant in DoorVariant.AllDoors)
                    {
                        if (doorVariant is BreakableDoor breakable)
                        {
                            if (breakable.IsInZone(MapGeneration.FacilityZone.HeavyContainment))
                            {
                                if (doorVariant.name != "CHECKPOINT")
                                {
                                    doorslist.Add(doorVariant);
                                    doorVariant.NetworkTargetState = true;
                                    doorVariant.ServerChangeLock(DoorLockReason.AdminCommand, true);
                                }
                            }

                            if (breakable.IsInZone(MapGeneration.FacilityZone.Entrance))
                            {
                                doorVariant.NetworkTargetState = false;
                                doorVariant.ServerChangeLock(DoorLockReason.AdminCommand, true) ;
                            }
                        }

                    }
                }


                int doorid = random.Next(doorslist.Count);

                UnityEngine.Vector3 vector3 = doorslist[doorid].transform.position;

                UnityEngine.Vector3 location = new UnityEngine.Vector3(vector3.x, vector3.y + 2, vector3.z);

                player.Position = location;

                FirearmCreation(player, item);

            }


            response = "You're equipped item has been upgraded";

            return true;
        }


        private void FirearmCreation(Player player, ItemType item)
        {

            Firearm firearm = player.ReferenceHub.inventory.ServerAddItem(item) as Firearm;

            firearm.Status = new FirearmStatus(firearm.AmmoManagerModule.MaxAmmo, FirearmStatusFlags.Chambered, 0);

        }
    }
}
