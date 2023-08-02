using System.Collections.Generic;
using RoundStart.EventHandler.EventManager;

namespace RoundStart
{
    public class Config
    {
        public static bool SCP914ProcessPlayerEvent => true;
        public static bool SCP079NoiseEvent => true;
        public List<string> dev_id { get; set; } = new List<string>();
        public static bool KeycardDoorEvent => true;
    }
}