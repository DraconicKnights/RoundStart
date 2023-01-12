using PluginAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundStart.Events
{
    public class PlayerList
    {

        private static List<IPlayer> players = new List<IPlayer>();


        public static List<IPlayer> GetPlayers()
        {
            return players;
        }

        public static void AddPlayer(IPlayer player)
        {
            players.Add(player);
        }

        public static void RemovePlayer(IPlayer player)
        {
            players.Remove(player);
        }

        public static void Clear()
        {
            players.Clear();
        }



    }
}
