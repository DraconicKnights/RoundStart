using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using PlayerRoles;
using Interactables.Interobjects.DoorUtils;
using InventorySystem.Items;
using Interactables.Interobjects;
using RoundStart.Events.Items;
using System;
using System.Collections;
using CustomPlayerEffects;
using PluginAPI.Events;
using UnityEngine;

namespace RoundStart.Events
{
    public class KeycardDoorEvent
    {


        [PluginEvent(ServerEventType.RoundStart)]
        void onStart()
        {
            var allitems = (ItemType[]) Enum.GetValues(typeof(ItemType));
            
            foreach (ItemType item in allitems)
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

            Config config = new Config();
            if (!config.KeycardDoorEvent)
                return;

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
        
        

        [PluginEvent(ServerEventType.PlayerHandcuff)]
        private void onHandcuff(PlayerHandcuffEvent playerHandcuffEvent)
        {
            Player player = playerHandcuffEvent.Player;

            var target = playerHandcuffEvent.Target;
            
            if (!player.ReferenceHub.IsHuman())
                return;

            if (player.Role == RoleTypeId.ClassD)
                return;
            
            if (target.ReferenceHub.IsSCP())
                return;

            player.EffectsManager.EnableEffect<MovementBoost>(1, false);
            target.EffectsManager.ChangeState<MovementBoost>(2, 10, false);
            
            
        }
        

    }
}
