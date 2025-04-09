using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace OODProject
{
    //This class holds important information about the current build that is used for compatibility checks and filtering in MainWindow and ChoosePart
    //It takes smaller bits of information about each part from the database.
    public class CurrentBuild
    {
        public string CPUPlatform { get; set; }
        public int CPUTdp { get; set; }
        public int CoolerMaxTDP { get; set; }
        public string MBPlatform { get; set; }
        public string MBFormFactor { get; set; }
        public string MBMemoryType { get; set; }
        public int GPULength { get; set; }
        public int GPUPsuReq { get; set; }
        public int CaseMaxGPULength { get; set; }
        public string CaseFormFactor { get; set; }
        public int PSUPower { get; set; }
        public string RAMType { get; set; } 
    }
}
