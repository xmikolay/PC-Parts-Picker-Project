﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject
{
    public class GenericPart
    {
        public int GenericPartID { get; set; }
        public string PartName { get; set; }
        public decimal Price { get; set; } 
    }

    public class CPU
    {
        public int CpuID { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public double BaseClock { get; set; }
        public double BoostClock { get; set; }
        public string Architecture { get; set; }
        public int TDP { get; set; }
        public bool IncludesCooler { get; set; } 
        
        public int CPUCoolerID { get; set; }
        public virtual CPUCooler CompatibleCooler { get; set; }
    }

    public class Motherboard
    {
        public int MotherboardID { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public string Chipset { get; set; }
        public int MaxMemoryCapacity { get; set; }
        public int MemorySlots { get; set; }
        public string FormFactor { get; set; }

        public string MemoryType { get; set; }

        public ICollection<GPU> CompatibleGPUs { get; set; }
    }

    public class RAM
    {
        public int RamID { get; set; }
        public string Name { get; set; }
        public string RAMType { get; set; }
        public int Modules { get; set; }
        public int Capacity { get; set; }
        public int Speed { get; set; }
        public int CASLatency { get; set; }
    }

    public class GPU
    {
        public int GpuID { get; set; }
        public string Name { get; set; }
        public string MemoryType { get; set; }
        public int MemorySize { get; set; }
        public int TDP { get; set; }
        public string Interface { get; set; }
        public string ExternalPower { get; set; }
        public int GPULength { get; set; }

        public int PSURequirementID { get; set; }
        public virtual PSU RequiredPSU { get; set; }
    }

    public class PSU
    {
        public int PsuID { get; set; }
        public string Name { get; set; }
        public int Wattage { get; set; }
        public string Size { get; set; }
        public string Efficiency { get; set; }
        public string Modularity { get; set; }

        public ICollection<GPU> CompatibleGPUs { get; set; }
    }

    public class Case
    {
        public int CaseID { get; set; }
        public string Name { get; set; }
        public string FormFactor { get; set; }
        public int MaxGPULength { get; set; }
        public int MaxCoolerHeight { get; set; }
        public string FansIncluded { get; set; }

        public ICollection<GPU> CompatibleGPUs { get; set; }
    }

    public class Storage
    {
        public int StorageID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public string Interface { get; set; }
    }

    public class CPUCooler 
    {
        public int CPUCoolerID { get; set ; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int MaxTDP { get; set; }
    }

}
