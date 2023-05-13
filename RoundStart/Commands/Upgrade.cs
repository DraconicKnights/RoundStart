using CommandSystem;
using Interactables.Interobjects;
using Interactables.Interobjects.DoorUtils;
using InventorySystem.Items;
using MapGeneration;
using PluginAPI.Core;
using PluginAPI.Core.Zones;
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
        public string Command => "upgrade";

        public string[] Aliases => null;

        public string Description => "Upgrade the current equipped item";

        public string[] Usage => null;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            if (!sender.CheckPermission(PlayerPermissions.GivingItems))
            {
                response = "You don't have permission to use this command";
                return true;
            }


            foreach (Player player in Player.GetPlayers())
            {

                player.SetRole(PlayerRoles.RoleTypeId.ClassD, PlayerRoles.RoleChangeReason.RemoteAdmin);
                player.AddItem(ItemType.GunRevolver);


            }


            response = "You're equipped item has been upgraded";

            return true;
        }
    }
}
