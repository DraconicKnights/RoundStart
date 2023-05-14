using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using PluginAPI.Core.Interfaces;
using PlayerRoles;
using Interactables.Interobjects.DoorUtils;
using MapGeneration;
using InventorySystem.Items;
using Interactables.Interobjects;
using System.Linq;
using RoundStart.Events.Items;
using InventorySystem.Items.Firearms;
using PluginAPI.Core.Zones.Entrance;

namespace RoundStart.Events
{
    public class KeycardDoorEvent
    {


        [PluginEvent(ServerEventType.RoundStart)]
        void onStart()
        {
            Itemlist.addItem(ItemType.GunFSP9);
            Itemlist.addItem(ItemType.GunCOM18);
            Itemlist.addItem(ItemType.GunE11SR);
            Itemlist.addItem(ItemType.GunCOM18);
            Itemlist.addItem(ItemType.GunCrossvec);
            Itemlist.addItem(ItemType.GunRevolver);
            Itemlist.addItem(ItemType.GunLogicer);
            Itemlist.addItem(ItemType.GunShotgun);

            
        }

        [PluginEvent(ServerEventType.RoundRestart)]
        void onRestart()
        {
            Itemlist.itemClear();
        }

        [PluginEvent(ServerEventType.PlayerInteractDoor)]
        void oninteractDoor(IPlayer player, DoorVariant doorVariant, bool canOpen)
        {

            Config config = new Config();
            if (!config.KeycardDoorEvent)
                return;

            Player player1 = (Player)player;

            if (canOpen)
                return;

            doorEvent(player1, doorVariant);

            
        }


        private void doorEvent(Player player, DoorVariant doorVariant)
        {

            if (doorVariant is CheckpointDoor checkpoint)
            {
                foreach (ItemBase item in player.Items)
                {
                    switch (item.ItemTypeId)
                    {
                        case ItemType.KeycardO5:
                            if (!doorVariant.IsConsideredOpen())
                                checkpoint.NetworkTargetState = true;
                            if (doorVariant.IsConsideredOpen())
                                checkpoint.NetworkTargetState = false;
                            break;
                        case ItemType.KeycardNTFCommander:
                            if (!doorVariant.IsConsideredOpen())
                                checkpoint.NetworkTargetState = true;
                            if (doorVariant.IsConsideredOpen())
                                checkpoint.NetworkTargetState = false;
                            break;
                    }
                }
            }

            if (doorVariant is PryableDoor pryableDoor)
            {
                foreach (ItemBase item in player.Items)
                {
                    switch (item.ItemTypeId)
                    {
                        case ItemType.KeycardO5:
                            if (!doorVariant.IsConsideredOpen())
                                pryableDoor.NetworkTargetState = true;
                            if (doorVariant.IsConsideredOpen())
                                pryableDoor.NetworkTargetState = false;
                            break;
                    }
                }
            }
        }
    }
}
