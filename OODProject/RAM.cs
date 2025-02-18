using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject
{
    public class RAM : GenericPart
    {
        public string RAMType { get; set; }
        public string Modules { get; set; }
        public int Capacity { get; set; }
        public int Speed { get; set; }
        public int CASLatency { get; set; }
        public bool RGB {  get; set; }
    }
}
