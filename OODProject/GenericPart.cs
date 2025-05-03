using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject
    //This class is just used to part object properties
{
    public class GenericPart
    {
        [Key]
        public int GenericPartID { get; set; }

        public string PartName { get; set; }
        public decimal Price { get; set; } 
    }

    public class CPU
    {
        [Key]
        public int CpuID { get; set; }

        public string Name { get; set; }
        public string Platform { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public double BaseClock { get; set; }
        public double BoostClock { get; set; }
        public string Architecture { get; set; }
        public int TDP { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public bool IncludesCooler { get; set; } 
        
        public int? CPUCoolerID { get; set; }
        public virtual CPUCooler CompatibleCooler { get; set; }

        public override string ToString()
        {
            return $"{Name}\t{Price:c}";
        }
    }

    public class Motherboard
    {
        [Key]
        public int MotherboardID { get; set; }

        public string Name { get; set; }
        public string Platform { get; set; }
        public string Chipset { get; set; }
        public int MaxMemoryCapacity { get; set; }
        public int MemorySlots { get; set; }
        public string FormFactor { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public string MemoryType { get; set; }

        //public ICollection<GPU> CompatibleGPUs { get; set; }
    }

    public class RAM
    {
        [Key]
        public int RamID { get; set; }

        public string Name { get; set; }
        public string RAMType { get; set; }
        public int Modules { get; set; }
        public int Capacity { get; set; }
        public int Speed { get; set; }
        public int CASLatency { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }

    public class GPU
    {
        [Key]
        public int GpuID { get; set; }

        public string Name { get; set; }
        public string MemoryType { get; set; }
        public int MemorySize { get; set; }
        public int TDP { get; set; }
        public string Interface { get; set; }
        public string ExternalPower { get; set; }
        public int GPULength { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int PSURequirement { get; set; }

        //public int PSURequirementID { get; set; }
        //public virtual PSU RequiredPSU { get; set; }
    }

    public class PSU
    {
        [Key]
        public int PsuID { get; set; }

        public string Name { get; set; }
        public int Wattage { get; set; }
        public string Size { get; set; }
        public string Efficiency { get; set; }
        public string Modularity { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        //public ICollection<GPU> CompatibleGPUs { get; set; }
    }

    public class Case
    {
        [Key]
        public int CaseID { get; set; }

        public string Name { get; set; }
        public string FormFactor { get; set; }
        public int MaxGPULength { get; set; }
        public int MaxCoolerHeight { get; set; }
        public string FansIncluded { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        //public ICollection<GPU> CompatibleGPUs { get; set; }
    }

    public class Storage
    {
        [Key]
        public int StorageID { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public string Interface { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }

    public class CPUCooler 
    {
        [Key]
        public int CPUCoolerID { get; set ; }

        public string Name { get; set; }
        public string Size { get; set; }
        public int MaxTDP { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }

    public class PartData : DbContext
    {
        public PartData() : base("PartsDatabase") { }
        public DbSet<GenericPart> GenericParts { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<PSU> PSUs { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<CPUCooler> CPUCoolers { get; set; }
    }
}