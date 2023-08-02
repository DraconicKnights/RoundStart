using System;
using Interactables.Interobjects;
using Interactables.Interobjects.DoorUtils;
using InventorySystem.Items;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;
using RoundStart.Items;

namespace RoundStart.EventHandler.Events
{
    public class KeycardDoorEvent
    {

        [PluginEvent(ServerEventType.RoundStart)]
        void onStart()
        {
            var allitems = (ItemType[]) Enum.GetValues(typeof(ItemType));
            
            foreach (var item in allitems)
            {
                Itemlist.addItem(item);
            }
        }
        
        [PluginEvent(ServerEventType.RoundRestart)]
        void onRestart()
        {
            Itemlist.itemClear();
        }

        #region DoorController
        
        [PluginEvent(ServerEventType.PlayerInteractDoor)]
        void oninteractDoor(PlayerInteractDoorEvent playerInteractDoorEvent)
        {

            if (!Config.SCP914ProcessPlayerEvent == true) return;

            Player player = playerInteractDoorEvent.Player;
            
            var doorVariant = playerInteractDoorEvent.Door;

            if (playerInteractDoorEvent.CanOpen)
                return;

            doorEvent(player, doorVariant);
            

        }
        private void doorEvent(Player player, DoorVariant doorVariant)
        {
            switch (doorVariant)
            {
                case CheckpointDoor checkpoint:
                {
                    checkpointDoorTrigger(checkpoint, player, doorVariant);
                    break;
                }
                case PryableDoor pryableDoor:
                {
                    pryableDoorTrigger(pryableDoor, player, doorVariant);
                    break;
                }
                case BreakableDoor breakableDoor:
                {
                    breakableDoorTrigger(breakableDoor, player, doorVariant);
                    break;
                }
            }
        }

        private void checkpointDoorTrigger(CheckpointDoor checkpoint, Player player, DoorVariant doorVariant)
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

        private void pryableDoorTrigger(PryableDoor pryableDoor, Player player, DoorVariant doorVariant)
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

        private void breakableDoorTrigger(BreakableDoor breakableDoor, Player player, DoorVariant doorVariant)
        {
            foreach (ItemBase item in player.Items)
            {
                switch (item.ItemTypeId)
                {
                    case ItemType.KeycardO5:
                        if (!doorVariant.IsConsideredOpen())
                            breakableDoor.NetworkTargetState = true;
                        if (doorVariant.IsConsideredOpen())
                            breakableDoor.NetworkTargetState = false;
                        break;
                }
            }
        }
        
        #endregion
        
    }
}
