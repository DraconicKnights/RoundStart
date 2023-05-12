using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using PlayerRoles;
using UnityEngine;
using Random = System.Random;
using PluginAPI.Core.Interfaces;


namespace RoundStart.Events
{
    public class SCP079NoiseEvent
    {

        Random random = new Random();

        [PluginEvent(ServerEventType.PlayerMakeNoise)]
        public void onNoise(IPlayer player)
        {

            if (!Config.SCP079NoiseEvent == true)
                return;

            Player player1 = (Player)player;

            int id = random.Next(10);

            switch (id)
            {
                case 5:
                    playerNoiseEvent(player1);
                    player1.SendBroadcast("You have made too much noise and alerted 079", 10, Broadcast.BroadcastFlags.Normal, false);
                    break;
                default:
                    break;
            }


        }


        public void playerNoiseEvent(Player player)
        {
            foreach (Player playerlist in Player.GetPlayers())
            {
                if (playerlist.Role == RoleTypeId.Scp079 && playerlist.IsAlive)
                {
                    Player SCP = playerlist as Player;

                    Player target = player;

                    broadcastEvent(SCP, target);
                } else
                {
                    return;
                }
            }
        }

        private void broadcastEvent(Player SCP, Player target)
        {
            string name = target.Room.name;

            SCP.SendBroadcast(target.RoleName.ToString() + " Detected in " + name, 10, Broadcast.BroadcastFlags.AdminChat, false);
        }



    }

}
