using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;
using Random = System.Random;


namespace RoundStart.EventHandler.Events
{
    public class Scp079NoiseEvent
    {
        private Random _random = new Random();

        [PluginEvent(ServerEventType.PlayerMakeNoise)]
        public void OnNoise(PlayerMakeNoiseEvent playerMakeNoiseEvent)
        {
            
            if (new Config().Scp079NoiseEvent != true) return;
            
            var player1 = playerMakeNoiseEvent.Player;

            var id = _random.Next(10);

            switch (id)
            {
                case 5:
                    PlayerNoiseEvent(player1);
                    player1.SendBroadcast("You have made too much noise and alerted 079", 10, Broadcast.BroadcastFlags.Normal, false);
                    break;
                default:
                    break;
            }


        }


        private void PlayerNoiseEvent(Player player)
        {
            foreach (Player playerlist in Player.GetPlayers())
            {
                if (playerlist.Role == RoleTypeId.Scp079 && playerlist.IsAlive)
                {
                    Player scp = playerlist as Player;

                    Player target = player;

                    BroadcastEvent(scp, target);
                } else
                {
                    return;
                }
            }
        }

        private void BroadcastEvent(Player scp, Player target)
        {
            var name = target.Room.name;

            scp.SendBroadcast(target.RoleName.ToString() + " Detected in " + name, 10, Broadcast.BroadcastFlags.AdminChat, false);
        }


    }

}
