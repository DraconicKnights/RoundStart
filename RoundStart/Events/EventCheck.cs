using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundStart.Events
{
    public class EventCheck
    {
        private bool active;

        public EventCheck(bool active)
        {
            Active = active;
        }

        public bool Active
        {
            get { return active; }
            set
            {
                active = value;
            }
        } 
    }
}
