using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace OODProject
{
    public class CurrentBuild
    {
        public string CPUPlatform { get; set; }
        public int CPUTdp { get; set; }
        public int CoolerMaxTDP { get; set; }
        public string MBPlatform { get; set; }
        public string MBFormFactor { get; set; }
        public int MBMaxMemoryCapacity { get; set; }
        public string MBMemoryType { get; set; }
        public int GPULength { get; set; }
        public int GPUPsuReq { get; set; }
        public int CaseMaxGPULength { get; set; }
        public string CaseFormFactor { get; set; }
        public int PSUPower { get; set; }
        public int RAMCapacity { get; set; }
        public string RAMType { get; set; } 
    }
}
