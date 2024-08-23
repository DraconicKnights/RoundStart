using System;
using CommandSystem;
using PlayerRoles;
using PluginAPI.Core;

namespace RoundStart.Commands.Test
{
    [Command("ghosthunt", "Enables the ghost hunt event", null, PlayerPermissions.FacilityManagement, 
        new Type[] {typeof(RemoteAdminCommandHandler), typeof(GameConsoleCommandHandler), typeof(ClientCommandHandler)})]
    public class GhostCommand : CommandCore
    {
        protected override bool Execute(Player player, ArraySegment<string> arguments, out string response)
        {
            player.SetRole(RoleTypeId.Scp939);
            response = "Test";
            return true;
        }
    }
}