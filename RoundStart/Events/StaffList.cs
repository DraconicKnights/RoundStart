using PluginAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundStart.Events
{
    public class StaffList
    {
        private static List<IPlayer> staff = new List<IPlayer>();


        public static List<IPlayer> GetPlayers()
        {
            return staff;
        }

        public static void AddPlayer(IPlayer player)
        {
            staff.Add(player);
        }

        public static void RemovePlayer(IPlayer player)
        {
            staff.Remove(player);
        }

        public static void Clear()
        {
            staff.Clear();
        }
    }
}
