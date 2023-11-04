using System;
using System.Collections.Generic;
using System.Linq;
using CommandSystem;
using PluginAPI.Core;
using RemoteAdmin;
using Utils;

namespace RoundStart.Commands.CommandHandler
{
    public static class CommandControl
    {
        public static bool CommandCheck(this ICommandSender sender, CustomCommandHandler.ICustomCommandHandler command,
            ArraySegment<string> args, out string response, out List<Player> players,
            out PlayerCommandSender playerCommandSender)
        {
            players = new List<Player>();
            playerCommandSender = null;

            if (!command.ServerCommand && !(playerCommandSender is PlayerCommandSender playerSender))
            {
                response = "You must be a player to use this command";
                return false;
            }

            if (args.Count < command.Usage.Length)
            {
                response = $"Missing Arguments: {command.Usage[args.Count]}";
                return false;
            }
            
            if (command.Usage.Contains("%player%"))
            {
                var index = command.Usage.IndexOf("%player%");

                var hubs = RAUtils.ProcessPlayerIdOrNamesList(args, index, out var newArgs, false);

                if (hubs.Count < 1)
                {
                    response = $"No player(s) found for: {args.ElementAt(index)}";
                    return false;
                }
                else
                {
                    players.AddRange(hubs.Select(Player.Get));
                }
            }

            response = string.Empty;
            return true;
        }
    }
}