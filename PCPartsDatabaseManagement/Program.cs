using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProject;

namespace PCPartsDatabaseManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PartData db = new PartData();

            using (db)
            {
                //CPU cpu1 = new CPU { CpuID = 1, Name = "Intel Core Ultra 9 285K", Platform = "LGA1851", Cores = 24, Threads = 32, BaseClock = 3.2, BoostClock = 6.0, IncludesCooler = false, Architecture = "Arrow Lake", TDP = 125, Price = 700m, Image = "Images/Core 9 285k" };
                //CPU cpu2 = new CPU { CpuID = 2, Name = "AMD Ryzen 9 9950X3D", Platform = "AM5", Cores = 16, Threads = 32, BaseClock = 3.5, BoostClock = 5.7, IncludesCooler = false, Architecture = "Zen 5 3D V-Cache", TDP = 170, Price = 650m, Image = "Images/9950x3d" };
                //CPU cpu3 = new CPU { CpuID = 3, Name = "Intel Core Ultra 7 265K", Platform = "LGA1851", Cores = 20, Threads = 28, BaseClock = 3.0, BoostClock = 5.5, IncludesCooler = false, Architecture = "Arrow Lake", TDP = 125, Price = 400m, Image = "Images/Core 7 265k" };
                //CPU cpu4 = new CPU { CpuID = 4, Name = "AMD Ryzen 9 7950X", Platform = "AM5", Cores = 16, Threads = 32, BaseClock = 4.5, BoostClock = 5.7, IncludesCooler = false, Architecture = "Zen 4", TDP = 170, Price = 530m, Image = "Images/7950x" };
                //CPU cpu5 = new CPU { CpuID = 5, Name = "AMD Ryzen 5 5600X", Platform = "AM4", Cores = 6, Threads = 12, BaseClock = 3.7, BoostClock = 4.6, IncludesCooler = true, Architecture = "Zen 3", TDP = 65, Price = 140m, Image = "Images/5600x" };
                //CPU cpu6 = new CPU { CpuID = 6, Name = "Intel Core i3-12100F", Platform = "LGA1700", Cores = 4, Threads = 8, BaseClock = 3.3, BoostClock = 4.3, IncludesCooler = false, Architecture = "Alder Lake", TDP = 58, Price = 80m, Image = "Images/12100f" };

                //db.CPUs.Add(cpu1);
                //db.CPUs.Add(cpu2);
                //db.CPUs.Add(cpu3);
                //db.CPUs.Add(cpu4);
                //db.CPUs.Add(cpu5);
                //db.CPUs.Add(cpu6);

                //Console.WriteLine("Added CPU's to database");

                //db.SaveChanges();

                //Console.WriteLine("Saved to Database");

                //Motherboard mb1 = new Motherboard { MotherboardID = 1, Name = "MSI MAG Z890 Tomahawk WIFI", Platform = "LGA1851", Chipset = "Z890", MaxMemoryCapacity = 256, MemorySlots = 4, FormFactor = "ATX", Price = 365.00m, Image = "Images/MSI Z890 Tomahawk WIFI", MemoryType = "DDR5" };
                //Motherboard mb2 = new Motherboard { MotherboardID = 2, Name = "Gigabyte Z890M Gaming X", Platform = "LGA1851", Chipset = "Z890", MaxMemoryCapacity = 256, MemorySlots = 4, FormFactor = "MATX", Price = 230.00m, Image = "Images/Gigabyte z890m", MemoryType = "DDR5" };
                //Motherboard mb3 = new Motherboard { MotherboardID = 3, Name = "MSI B760 GAMING PLUS WIFI", Platform = "LGA1700", Chipset = "B760", MaxMemoryCapacity = 256, MemorySlots = 4, FormFactor = "ATX", Price = 180.00m, Image = "Images/MSI B760 Gaming", MemoryType = "DDR5" };
                //Motherboard mb4 = new Motherboard { MotherboardID = 4, Name = "ASUS ROG Crosshair X870E Hero", Platform = "AM5", Chipset = "X870E", MaxMemoryCapacity = 256, MemorySlots = 4, FormFactor = "ATX", Price = 740.99m, Image = "Images/ROG Crosshair X870e", MemoryType = "DDR5" };
                //Motherboard mb5 = new Motherboard { MotherboardID = 5, Name = "ASUS TUF GAMING B650-PLUS WIFI", Platform = "AM5", Chipset = "B650", MaxMemoryCapacity = 128, MemorySlots = 4, FormFactor = "ATX", Price = 179.99m, Image = "Images/Asus tuf", MemoryType = "DDR5" };
                //Motherboard mb6 = new Motherboard { MotherboardID = 6, Name = "MSI MPG B550 GAMING CARBON WIFI", Platform = "AM4", Chipset = "B550", MaxMemoryCapacity = 128, MemorySlots = 4, FormFactor = "ATX", Price = 140.00m, Image = "Images/MSI B550", MemoryType = "DDR4" };

                //db.Motherboards.Add(mb1);
                //db.Motherboards.Add(mb2);
                //db.Motherboards.Add(mb3);
                //db.Motherboards.Add(mb4);
                //db.Motherboards.Add(mb5);
                //db.Motherboards.Add(mb6);

                //Console.WriteLine("Added Motherboards to database");

                //db.SaveChanges();

                //Console.WriteLine("Saved to Database");

                //RAM ram1 = new RAM { RamID = 1, Name = "Corsair Vengeance 32GB (2x16GB) DDR5-6000", RAMType = "DDR5", Modules = 2, Capacity = 32, Speed = 6000, CASLatency = 36, Price = 149.99m, Image = "Images/corsairddr5" };
                //RAM ram2 = new RAM { RamID = 2, Name = "G.Skill Trident Z5 RGB 64GB (2x32GB) DDR5-6400", RAMType = "DDR5", Modules = 2, Capacity = 64, Speed = 6400, CASLatency = 32, Price = 329.99m, Image = "Images/gskillddr5" };
                //RAM ram3 = new RAM { RamID = 3, Name = "Kingston Fury Beast 16GB (2x8GB) DDR5-5600", RAMType = "DDR5", Modules = 2, Capacity = 16, Speed = 5600, CASLatency = 40, Price = 109.99m, Image = "Images/kingston" };
                //RAM ram4 = new RAM { RamID = 4, Name = "Corsair Vengeance LPX 32GB (2x16GB) DDR4-3600", RAMType = "DDR4", Modules = 2, Capacity = 32, Speed = 3600, CASLatency = 18, Price = 99.99m, Image = "Images/corsairddr4" };
                //RAM ram5 = new RAM { RamID = 5, Name = "G.Skill Ripjaws V 16GB (2x8GB) DDR4-3200", RAMType = "DDR4", Modules = 2, Capacity = 16, Speed = 3200, CASLatency = 16, Price = 59.99m, Image = "Images/gskillddr4" };
                //RAM ram6 = new RAM { RamID = 6, Name = "Team T-Force Delta RGB 64GB (2x32GB) DDR4-4000", RAMType = "DDR4", Modules = 2, Capacity = 64, Speed = 4000, CASLatency = 18, Price = 199m, Image = "Images/tforce" };

                //db.RAMs.Add(ram1);
                //db.RAMs.Add(ram2);
                //db.RAMs.Add(ram3);
                //db.RAMs.Add(ram4);
                //db.RAMs.Add(ram5);
                //db.RAMs.Add(ram6);

                //Console.WriteLine("Added RAM to database");

                //db.SaveChanges();

                //Console.WriteLine("Saved to Database");

                GPU gpu1 = new GPU { GpuID = 1, Name = "NVIDIA GeForce RTX 4090", MemoryType = "GDDR6X", MemorySize = 24, TDP = 450, Interface = "PCIe 4.0 x16", ExternalPower = "3x 8-pin (or 1x 16-pin)", GPULength = 304, Price = 1599.99m, PSURequirement = 850 };
                GPU gpu2 = new GPU { GpuID = 2, Name = "NVIDIA GeForce RTX 4080 SUPER", MemoryType = "GDDR6X", MemorySize = 16, TDP = 320, Interface = "PCIe 4.0 x16", ExternalPower = "2x 8-pin (or 1x 16-pin)", GPULength = 305, Price = 999.99m, PSURequirement = 750 };
                GPU gpu3 = new GPU { GpuID = 3, Name = "NVIDIA GeForce RTX 4070 Ti SUPER", MemoryType = "GDDR6X", MemorySize = 16, TDP = 285, Interface = "PCIe 4.0 x16", ExternalPower = "1x 16-pin", GPULength = 285, Price = 799.99m, PSURequirement = 450 };
                GPU gpu4 = new GPU { GpuID = 4, Name = "AMD Radeon RX 7900 XTX", MemoryType = "GDDR6", MemorySize = 24, TDP = 355, Interface = "PCIe 4.0 x16", ExternalPower = "2x 8-pin", GPULength = 287, Price = 999.99m, PSURequirement = 850 };
                GPU gpu5 = new GPU { GpuID = 5, Name = "AMD Radeon RX 7900 XT", MemoryType = "GDDR6", MemorySize = 20, TDP = 300, Interface = "PCIe 4.0 x16", ExternalPower = "2x 8-pin", GPULength = 276, Price = 849.99m, PSURequirement = 750 };
                GPU gpu6 = new GPU { GpuID = 6, Name = "AMD Radeon RX 7800 XT", MemoryType = "GDDR6", MemorySize = 16, TDP = 263, Interface = "PCIe 4.0 x16", ExternalPower = "2x 8-pin", GPULength = 267, Price = 499.99m, PSURequirement = 700 };

                //Using this to Clear CPU table after incorrect seeding
                //
                //using (var context = new PartData())
                //{
                //    try
                //    {
                //        context.Database.ExecuteSqlCommand("DELETE FROM CPUs");

//        context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('CPUs', RESEED, 0)");

//        Console.WriteLine("CPU table cleared and identity reseeded.");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Error: " + ex.Message);
//    }
//}

//Console.ReadLine();
            }
        }
    }
}
