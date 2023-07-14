using System.Collections.Generic;

namespace RoundStart.EventHandler.EventManager
{
    public class EventList
    {
        private static List<Events> _eventsList = new List<Events>();

        public static List<Events> GetEventList()
        {
            return _eventsList;
        }

        public static void AddEvent(Events events)
        {
            _eventsList.Add(events);
        }

        public static void RemoveEvent(Events events)
        {
            _eventsList.Remove(events);
        }

        public static void RemoveAllEvents()
        {
            _eventsList.Clear();
        }
    }
}