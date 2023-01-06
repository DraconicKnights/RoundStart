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

        private List<IPlayer> players = new List<IPlayer>();


        public List<IPlayer> GetPlayers()
        {
            return players;
        }

        public void AddPlayer(IPlayer player)
        {
            players.Add(player);
        }

        public void RemovePlayer(IPlayer player)
        {
            players.Remove(player);
        }

        public void Clear()
        {
            players.Clear();
        }



    }
}
