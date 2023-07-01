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
using PluginAPI.Core.Items;
using System;
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

                    break;
                }
                case PryableDoor pryableDoor:
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

                    break;
                }
                case BreakableDoor breakableDoor:
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

                    break;
                }
            }
        }
    }
}
