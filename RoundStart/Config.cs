using System.Collections.Generic;

namespace RoundStart
{
    public class Config
    {
        public bool SCP914ProcessPlayerEvent { get; set; } = true;
        public bool SCP079NoiseEvent { get; set; } = true;
        public List<string> dev_id { get; set; } = new List<string>();
     

    }
}