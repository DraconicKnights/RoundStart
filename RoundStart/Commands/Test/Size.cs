using System;
using System.Reflection;
using CommandSystem;
using Mirror;
using PluginAPI.Core;
using RemoteAdmin;
using UnityEngine;

namespace RoundStart.Commands.Test
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Size : ICommand, IUsageProvider
    {

        public string Command => "size";
        public string[] Aliases => null;
        public string Description => "Use to change size";
        public string[] Usage => null;
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender playerCommandSender))
            {
                response = "This command can only be performed by players";
                return true;
            }
            
            if (!sender.CheckPermission(PlayerPermissions.Noclip))
            {
                response = "You don't have perms to use this command";
                return true;
            }

            var player = (Player)sender;

            try
            {
                player.ReferenceHub.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                var netserver =
                    typeof(NetworkServer).GetMethod("SendSpawnMessage", BindingFlags.NonPublic | BindingFlags.Static);
                foreach (var players in Player.GetPlayers())
                {
                    netserver.Invoke(null, new object[] { player.ReferenceHub.networkIdentity, players.Connection });
                }
            }
            catch (Exception e)
            {
                Log.Info($"Plugin Error: {e}");
            }

            response = "you have changed size";
            return true;
        }
    }
}