using System;
using PluginAPI.Core;

namespace RoundStart.Commands.Test
{
    public class Example : CommandCore
    {

        public Example(string command, string[] aliases, string description, string[] usage)
        {
            Command = command;
            Aliases = aliases;
            Description = description;
            Usage = usage;
        }
        
        protected override void Execute(Player player, ArraySegment<string> arguments)
        {
            
        }
    }
}