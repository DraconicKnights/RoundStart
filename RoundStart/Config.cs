using System.Collections.Generic;

namespace RoundStart
{
    public class Config
    {
        public bool Scp914ProcessPlayerEvent => false;
        public bool Scp079NoiseEvent => false;
        public List<string> DevID { get; set; } = new List<string>();
        public bool KeycardDoorEvent => false;
    }
}