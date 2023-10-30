using System.Collections.Generic;

namespace RoundStart
{
    public class Config
    {
        public bool Scp914ProcessPlayerEvent => true;
        public bool Scp079NoiseEvent => true;
        public List<string> DevID { get; set; } = new List<string>();
        public bool KeycardDoorEvent => true;
    }
}