using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject
{
    public class CPU : GenericPart
    {
        public int Cores { get; set; }
        public int Threads { get; set; }
        public double BaseClock { get; set; }
        public double BoostClock { get; set; }
        public bool IncludesCooler { get; set; }
        public string Architecture { get; set; }
    }
}
