using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundStart.Events
{
    public class EventClassList
    {
        static List<EventClasses> Events = new List<EventClasses>();

        public static List<EventClasses> GetEventList()
        {
            return Events;
        }

        public static void AddEvents()
        {

        }


    }
}
