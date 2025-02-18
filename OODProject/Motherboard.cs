using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject
{
    public class Motherboard : GenericPart
    {
        public string Platform { get; set; }
        public string Chipset { get; set; }
        public int MaxMemoryCapacity { get; set; }
        public int MemorySlots { get; set; }
        public string FormFactor { get; set; }
        public string MemoryType { get; set; }
        public string PCIESlots { get; set; }
        public string M2Slots { get; set; }
        public string EthernetSupport { get; set; }
        public string USBSupport { get; set; }
        public string WIFISupport { get; set; }
    }
}
