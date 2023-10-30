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
        private void OnStart()
        {
            var allitems = (ItemType[]) Enum.GetValues(typeof(ItemType));
            
            foreach (var item in allitems)
            {
                Itemlist.AddItem(item);
            }
        }
        
        [PluginEvent(ServerEventType.RoundRestart)]
        private void OnRestart()
        {
            Itemlist.ItemClear();
        }

        #region DoorController
        
        [PluginEvent(ServerEventType.PlayerInteractDoor)]
        private void OninteractDoor(PlayerInteractDoorEvent playerInteractDoorEvent)
        {
            
            if (new Config().KeycardDoorEvent != true) return;

            Player player = playerInteractDoorEvent.Player;
            
            var doorVariant = playerInteractDoorEvent.Door;

            if (playerInteractDoorEvent.CanOpen)
                return;

            DoorEvent(player, doorVariant);
            

        }
        private void DoorEvent(Player player, DoorVariant doorVariant)
        {
            switch (doorVariant)
            {
                case CheckpointDoor checkpoint:
                {
                    CheckpointDoorTrigger(checkpoint, player, doorVariant);
                    break;
                }
                case PryableDoor pryableDoor:
                {
                    PryableDoorTrigger(pryableDoor, player, doorVariant);
                    break;
                }
                case BreakableDoor breakableDoor:
                {
                    BreakableDoorTrigger(breakableDoor, player, doorVariant);
                    break;
                }
            }
        }

        private void CheckpointDoorTrigger(CheckpointDoor checkpoint, Player player, DoorVariant doorVariant)
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
                    case ItemType.KeycardMTFOperative:
                        if (!doorVariant.IsConsideredOpen())
                            checkpoint.NetworkTargetState = true;
                        if (doorVariant.IsConsideredOpen())
                            checkpoint.NetworkTargetState = false;
                        break;
                }
            }
        }

        private void PryableDoorTrigger(PryableDoor pryableDoor, Player player, DoorVariant doorVariant)
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

        private void BreakableDoorTrigger(BreakableDoor breakableDoor, Player player, DoorVariant doorVariant)
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
