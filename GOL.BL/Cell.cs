using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOL.BL
{
    public class Cell
    {
        public enum states { alive, dead};

        public Cell()
        {

        }

        public Cell(states state)
        {
            State = state;
        }

        public states State { get; set; }

    }
}
