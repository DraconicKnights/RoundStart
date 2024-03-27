using System;
using CommandSystem;
using PluginAPI.Core;

namespace RoundStart.Commands
{
    public abstract class CommandCore : ICommand, IUsageProvider
    {
        public string Command { get; protected set; }
        public string[] Aliases { get; protected set; }
        public string Description { get; protected set; }
        public string[] Usage { get; protected set; }

        protected abstract void Execute(Player player, ArraySegment<string> arguments);
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = (Player)sender;
            
            Execute(player, arguments);

            response = null;
            return true;
        }
    }
}