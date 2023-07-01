using System;
using System.Numerics;
using CommandSystem;
using PluginAPI.Core;

namespace RoundStart.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class Size : ICommand, IUsageProvider
    {

        public string Command => "size";
        public string[] Aliases { get; }
        public string Description => "Use to change size";
        public string[] Usage { get; } = { "value"};
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(PlayerPermissions.Noclip))
            {
                response = "You don't have perms to use this command";
                return true;
            }

            var player = (Player)sender;
            
            player.ReferenceHub.transform.localScale.Set(0.5f, 0.5f, 0.5f);

            response = null;
            return true;
        }
    }
}