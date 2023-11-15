using System;
using System.Linq;
using System.Reflection;
using CommandSystem;
using Mirror;
using PluginAPI.Core;
using RemoteAdmin;
using RoundStart.Commands.CommandHandler;
using UnityEngine;

namespace RoundStart.Commands.Test
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Size : CustomCommandHandler.ICustomCommandHandler
    {
        public string Command => "size";

        public string[] Aliases { get; } = 
        {
            "scale",
            "sv"
        };
        public string Description => "Use to change size";
        public string[] Usage { get; } =
        {
            "%players%",
            "x",
            "y",
            "z"
        };
        
        public string CustomPermission { get; }
        public bool ServerCommand { get; }
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            if (sender.CommandCheck(this, arguments, out response, out var targets, out var playerCommandSender))
                return false;
            
            if (!sender.CheckPermission(PlayerPermissions.Noclip))
            {
                response = "You don't have perms to use this command";
                return false;
            }
            
            if (!float.TryParse(arguments.Array[2], out var x) || !float.TryParse(arguments.Array[3], out var y) || !float.TryParse(arguments.Array[4], out var z))
            {
                response = "Valid scale not provided";
                return false;
            }

            foreach (var player in targets)
            {
                var netID = player.ReferenceHub.networkIdentity;
                player.ReferenceHub.gameObject.transform.localScale = new Vector3(1 * x, 1 * y, 1 * z);

                foreach (var networkConnection in Player.GetPlayers().Select(players => players.ReferenceHub.connectionToClient))
                {
                    typeof(NetworkServer)
                        .GetMethod("SendSpawnMessage", BindingFlags.NonPublic | BindingFlags.Static)
                        ?.Invoke(null, new object[] { netID, networkConnection });
                }
            }
            

            response = $"Scale of {targets.Count} {(targets.Count != 1 ? "players" : "player")} has been set to {x}, {y}, {z}";
            return true;
        }
    }
}