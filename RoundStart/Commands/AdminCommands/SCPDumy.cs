using System;
using CommandSystem;
using RoundStart.Commands.CommandHandler;

namespace RoundStart.Commands.AdminCommands
{
    public class SCPDumy : CustomCommandHandler.ICustomCommandHandler
    {

        public string Command { get; }
        public string[] Aliases { get; }
        public string Description { get; }
        public string[] Usage { get; }

        public string CustomPermission { get; }
        public bool ServerCommand { get; }
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender.CommandCheck(this, arguments, out response, out var players, out var playerCommandSender))
                return false;
            
            if (!sender.CheckPermission(PlayerPermissions.Noclip))
            {
                response = string.Empty;
                return false;
            }

            response = string.Empty;
            return true;

        }
    }
}