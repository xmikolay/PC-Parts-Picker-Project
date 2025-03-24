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
                #region Create Database
                CPU cpu1 = new CPU { CpuID = 1, Name = "Intel Core Ultra 9 285K", Platform = "LGA1851", Cores = 24, Threads = 32, BaseClock = 3.2, BoostClock = 6.0, IncludesCooler = false, Architecture = "Arrow Lake", TDP = 125, Price = 700m, Image = "/Images/Core 9 285k.jpg" };
                CPU cpu2 = new CPU { CpuID = 2, Name = "AMD Ryzen 9 9950X3D", Platform = "AM5", Cores = 16, Threads = 32, BaseClock = 3.5, BoostClock = 5.7, IncludesCooler = false, Architecture = "Zen 5 3D V-Cache", TDP = 170, Price = 650m, Image = "/Images/9950x3d.jpg" };
                CPU cpu3 = new CPU { CpuID = 3, Name = "Intel Core Ultra 7 265K", Platform = "LGA1851", Cores = 20, Threads = 28, BaseClock = 3.0, BoostClock = 5.5, IncludesCooler = false, Architecture = "Arrow Lake", TDP = 125, Price = 400m, Image = "/Images/Core 7 265k.jpg" };
                CPU cpu4 = new CPU { CpuID = 4, Name = "AMD Ryzen 9 7950X", Platform = "AM5", Cores = 16, Threads = 32, BaseClock = 4.5, BoostClock = 5.7, IncludesCooler = false, Architecture = "Zen 4", TDP = 170, Price = 530m, Image = "/Images/7950x.jpg" };
                CPU cpu5 = new CPU { CpuID = 5, Name = "AMD Ryzen 5 5600X", Platform = "AM4", Cores = 6, Threads = 12, BaseClock = 3.7, BoostClock = 4.6, IncludesCooler = true, Architecture = "Zen 3", TDP = 65, Price = 140m, Image = "/Images/5600x.jpg" };
                CPU cpu6 = new CPU { CpuID = 6, Name = "Intel Core i3-12100F", Platform = "LGA1700", Cores = 4, Threads = 8, BaseClock = 3.3, BoostClock = 4.3, IncludesCooler = false, Architecture = "Alder Lake", TDP = 58, Price = 80m, Image = "/Images/12100f.jpg" };

                db.CPUs.Add(cpu1);
                db.CPUs.Add(cpu2);
                db.CPUs.Add(cpu3);
                db.CPUs.Add(cpu4);
                db.CPUs.Add(cpu5);
                db.CPUs.Add(cpu6);

                Console.WriteLine("Added CPU's to database");

                db.SaveChanges();

                Console.WriteLine("Saved to Database");

                Motherboard mb1 = new Motherboard { MotherboardID = 1, Name = "MSI MAG Z890 Tomahawk WIFI", Platform = "LGA1851", Chipset = "Z890", MaxMemoryCapacity = 256, MemorySlots = 4, FormFactor = "ATX", Price = 365.00m, Image = "/Images/MSI Z890 Tomahawk WIFI.png", MemoryType = "DDR5" };
                Motherboard mb2 = new Motherboard { MotherboardID = 2, Name = "Gigabyte Z890M Gaming X", Platform = "LGA1851", Chipset = "Z890", MaxMemoryCapacity = 256, MemorySlots = 4, FormFactor = "MATX", Price = 230.00m, Image = "/Images/Gigabyte z890m.png", MemoryType = "DDR5" };
                Motherboard mb3 = new Motherboard { MotherboardID = 3, Name = "MSI B760 GAMING PLUS WIFI", Platform = "LGA1700", Chipset = "B760", MaxMemoryCapacity = 256, MemorySlots = 4, FormFactor = "ATX", Price = 180.00m, Image = "/Images/MSI B760 Gaming.png", MemoryType = "DDR5" };
                Motherboard mb4 = new Motherboard { MotherboardID = 4, Name = "ASUS ROG Crosshair X870E Hero", Platform = "AM5", Chipset = "X870E", MaxMemoryCapacity = 256, MemorySlots = 4, FormFactor = "ATX", Price = 740.99m, Image = "/Images/ROG Crosshair X870e.png", MemoryType = "DDR5" };
                Motherboard mb5 = new Motherboard { MotherboardID = 5, Name = "ASUS TUF GAMING B650-PLUS WIFI", Platform = "AM5", Chipset = "B650", MaxMemoryCapacity = 128, MemorySlots = 4, FormFactor = "ATX", Price = 179.99m, Image = "/Images/Asus tuf.jpg", MemoryType = "DDR5" };
                Motherboard mb6 = new Motherboard { MotherboardID = 6, Name = "MSI MPG B550 GAMING CARBON WIFI", Platform = "AM4", Chipset = "B550", MaxMemoryCapacity = 128, MemorySlots = 4, FormFactor = "ATX", Price = 140.00m, Image = "/Images/MSI B550.png", MemoryType = "DDR4" };

                db.Motherboards.Add(mb1);
                db.Motherboards.Add(mb2);
                db.Motherboards.Add(mb3);
                db.Motherboards.Add(mb4);
                db.Motherboards.Add(mb5);
                db.Motherboards.Add(mb6);

                Console.WriteLine("Added Motherboards to database");

                db.SaveChanges();

                Console.WriteLine("Saved to Database");

                RAM ram1 = new RAM { RamID = 1, Name = "Corsair Vengeance 32GB (2x16GB) DDR5-6000", RAMType = "DDR5", Modules = 2, Capacity = 32, Speed = 6000, CASLatency = 36, Price = 149.99m, Image = "/Images/corsairddr5.jpg" };
                RAM ram2 = new RAM { RamID = 2, Name = "G.Skill Trident Z5 RGB 64GB (2x32GB) DDR5-6400", RAMType = "DDR5", Modules = 2, Capacity = 64, Speed = 6400, CASLatency = 32, Price = 329.99m, Image = "/Images/gskillddr5.jpg" };
                RAM ram3 = new RAM { RamID = 3, Name = "Kingston Fury Beast 16GB (2x8GB) DDR5-5600", RAMType = "DDR5", Modules = 2, Capacity = 16, Speed = 5600, CASLatency = 40, Price = 109.99m, Image = "/Images/kingston.jpg" };
                RAM ram4 = new RAM { RamID = 4, Name = "Corsair Vengeance LPX 32GB (2x16GB) DDR4-3600", RAMType = "DDR4", Modules = 2, Capacity = 32, Speed = 3600, CASLatency = 18, Price = 99.99m, Image = "/Images/corsairddr4.jpg" };
                RAM ram5 = new RAM { RamID = 5, Name = "G.Skill Ripjaws V 16GB (2x8GB) DDR4-3200", RAMType = "DDR4", Modules = 2, Capacity = 16, Speed = 3200, CASLatency = 16, Price = 59.99m, Image = "/Images/gskillddr4.jpg" };
                RAM ram6 = new RAM { RamID = 6, Name = "Team T-Force Delta RGB 64GB (2x32GB) DDR4-4000", RAMType = "DDR4", Modules = 2, Capacity = 64, Speed = 4000, CASLatency = 18, Price = 199m, Image = "/Images/tforce.jpg" };

                db.RAMs.Add(ram1);
                db.RAMs.Add(ram2);
                db.RAMs.Add(ram3);
                db.RAMs.Add(ram4);
                db.RAMs.Add(ram5);
                db.RAMs.Add(ram6);

                Console.WriteLine("Added RAM to database");

                db.SaveChanges();

                Console.WriteLine("Saved to Database");

                GPU gpu1 = new GPU { GpuID = 1, Name = "NVIDIA GeForce RTX 4090", MemoryType = "GDDR6X", MemorySize = 24, TDP = 450, Interface = "PCIe 4.0 x16", ExternalPower = "1x 16-pin", GPULength = 304, Price = 3799.00m, PSURequirement = 850, Image = "/Images/4090.jpg" };
                GPU gpu2 = new GPU { GpuID = 2, Name = "ASUS Strix GeForce RTX 4080 SUPER", MemoryType = "GDDR6X", MemorySize = 16, TDP = 320, Interface = "PCIe 4.0 x16", ExternalPower = "1x 16-pin", GPULength = 358, Price = 1300.00m, PSURequirement = 850, Image = "/Images/4080 super.jpg" };
                GPU gpu3 = new GPU { GpuID = 3, Name = "Gigabyte GeForce RTX 4070 Ti SUPER GAMING OC", MemoryType = "GDDR6X", MemorySize = 16, TDP = 285, Interface = "PCIe 4.0 x16", ExternalPower = "1x 16-pin", GPULength = 300, Price = 1000.00m, PSURequirement = 750, Image = "/Images/4070.png" };
                GPU gpu4 = new GPU { GpuID = 4, Name = "PowerColor Hellhound RX 7900 XTX", MemoryType = "GDDR6", MemorySize = 24, TDP = 355, Interface = "PCIe 4.0 x16", ExternalPower = "2x 8-pin", GPULength = 320, Price = 999.99m, PSURequirement = 800, Image = "/Images/7900xtx.jpg" };
                GPU gpu5 = new GPU { GpuID = 5, Name = "ASUS TUF Gaming Radeon RX 7900 XT", MemoryType = "GDDR6", MemorySize = 20, TDP = 300, Interface = "PCIe 4.0 x16", ExternalPower = "2x 8-pin", GPULength = 352, Price = 849.99m, PSURequirement = 750, Image = "/Images/7900xt.png" };
                GPU gpu6 = new GPU { GpuID = 6, Name = "XFX Speedster QICK319 Radeon RX 7800 XT", MemoryType = "GDDR6", MemorySize = 16, TDP = 263, Interface = "PCIe 4.0 x16", ExternalPower = "2x 8-pin", GPULength = 335, Price = 550.99m, PSURequirement = 700, Image = "/Images/7800xt.jpg" };

                db.GPUs.Add(gpu1);
                db.GPUs.Add(gpu2);
                db.GPUs.Add(gpu3);
                db.GPUs.Add(gpu4);
                db.GPUs.Add(gpu5);
                db.GPUs.Add(gpu6);

                Console.WriteLine("Added GPUS to database");

                db.SaveChanges();

                Console.WriteLine("Saved to Database");

                PSU psu1 = new PSU { PsuID = 1, Name = "Corsair RM1000x", Wattage = 1000, Size = "ATX", Efficiency = "80+ Gold", Modularity = "Fully Modular", Price = 179.99m, Image = "/Images/RM1000x.jpg" };
                PSU psu2 = new PSU { PsuID = 2, Name = "Seasonic PRIME TX-850", Wattage = 850, Size = "ATX", Efficiency = "80+ Titanium", Modularity = "Fully Modular", Price = 249.99m, Image = "/Images/PRIMETX850.jpg" };
                PSU psu3 = new PSU { PsuID = 3, Name = "EVGA SuperNOVA 750 G6", Wattage = 750, Size = "ATX", Efficiency = "80+ Gold", Modularity = "Fully Modular", Price = 139.99m, Image = "/Images/SuperNOVA750G6.png" };
                PSU psu4 = new PSU { PsuID = 4, Name = "ASUS ROG STRIX 1000W", Wattage = 1000, Size = "ATX", Efficiency = "80+ Platinum", Modularity = "Fully Modular", Price = 209.99m, Image = "/Images/ROGSTRIX1000W.png" };
                PSU psu5 = new PSU { PsuID = 5, Name = "Cooler Master V850 SFX", Wattage = 850, Size = "SFX", Efficiency = "80+ Gold", Modularity = "Fully Modular", Price = 179.99m, Image = "/Images/V850SFX.jpg" };
                PSU psu6 = new PSU { PsuID = 6, Name = "Thermaltake Toughpower GF3 1200W", Wattage = 1200, Size = "ATX", Efficiency = "80+ Gold", Modularity = "Fully Modular", Price = 259.99m, Image = "/Images/ToughpowerGF31200W.jpg" };

                db.PSUs.Add(psu1);
                db.PSUs.Add(psu2);
                db.PSUs.Add(psu3);
                db.PSUs.Add(psu4);
                db.PSUs.Add(psu5);
                db.PSUs.Add(psu6);

                Console.WriteLine("Added PSUs to database");

                db.SaveChanges();

                Console.WriteLine("Saved to Database");

                Case case1 = new Case { CaseID = 1, Name = "Lian Li PC-O11 Dynamic", FormFactor = "ATX", MaxGPULength = 420, MaxCoolerHeight = 155, FansIncluded = "None", Price = 139.99m, Image = "/Images/PC-O11Dynamic.jpg" };
                Case case2 = new Case { CaseID = 2, Name = "Fractal Design Meshify 2", FormFactor = "ATX", MaxGPULength = 440, MaxCoolerHeight = 185, FansIncluded = "3x 140mm", Price = 159.99m, Image = "/Images/Meshify2.jpg" };
                Case case3 = new Case { CaseID = 3, Name = "NZXT H7 Flow", FormFactor = "ATX", MaxGPULength = 400, MaxCoolerHeight = 185, FansIncluded = "2x 120mm", Price = 129.99m, Image = "/Images/H7Flow.png" };
                Case case4 = new Case { CaseID = 4, Name = "Corsair 4000D Airflow", FormFactor = "ATX", MaxGPULength = 360, MaxCoolerHeight = 170, FansIncluded = "2x 120mm", Price = 104.99m, Image = "/Images/4000DAirflow.jpg" };
                Case case5 = new Case { CaseID = 5, Name = "Cooler Master NR200P", FormFactor = "Mini-ITX", MaxGPULength = 330, MaxCoolerHeight = 155, FansIncluded = "2x 120mm", Price = 119.99m, Image = "/Images/NR200P.png" };
                Case case6 = new Case { CaseID = 6, Name = "Phanteks Eclipse G360A", FormFactor = "ATX", MaxGPULength = 400, MaxCoolerHeight = 162, FansIncluded = "3x 120mm", Price = 99.99m, Image = "/Images/G360A.jpg" };

                db.Cases.Add(case1);
                db.Cases.Add(case2);
                db.Cases.Add(case3);
                db.Cases.Add(case4);
                db.Cases.Add(case5);
                db.Cases.Add(case6);

                Console.WriteLine("Added Cases to database");

                db.SaveChanges();

                Console.WriteLine("Saved to Database");

                Storage storage1 = new Storage { StorageID = 1, Name = "Samsung 990 Pro 2TB", Type = "NVMe M.2", Capacity = 2000, Interface = "PCIe 4.0 x4", Price = 179.99m, Image = "/Images/990Pro2TB.jpg" };
                Storage storage2 = new Storage { StorageID = 2, Name = "Western Digital Black SN850X 1TB", Type = "NVMe M.2", Capacity = 1000, Interface = "PCIe 4.0 x4", Price = 89.99m, Image = "/Images/SN850X1TB.jpg" };
                Storage storage3 = new Storage { StorageID = 3, Name = "Crucial T700 2TB", Type = "NVMe M.2", Capacity = 2000, Interface = "PCIe 5.0 x4", Price = 289.99m, Image = "/Images/T7002TB.png" };
                Storage storage4 = new Storage { StorageID = 4, Name = "Sabrent Rocket 4 Plus 4TB", Type = "NVMe M.2", Capacity = 4000, Interface = "PCIe 4.0 x4", Price = 649.99m, Image = "/Images/Rocket4Plus4TB.jpg" };
                Storage storage5 = new Storage { StorageID = 5, Name = "Kingston Fury Renegade 1TB", Type = "NVMe M.2", Capacity = 1000, Interface = "PCIe 4.0 x4", Price = 99.99m, Image = "/Images/FuryRenegade1TB.jpg" };
                Storage storage6 = new Storage { StorageID = 6, Name = "ADATA XPG Gammix S70 Blade 2TB", Type = "NVMe M.2", Capacity = 2000, Interface = "PCIe 4.0 x4", Price = 159.99m, Image = "/Images/GammixS702TB.jpg" };

                db.Storages.Add(storage1);
                db.Storages.Add(storage2);
                db.Storages.Add(storage3);
                db.Storages.Add(storage4);
                db.Storages.Add(storage5);
                db.Storages.Add(storage6);

                Console.WriteLine("Added Storage to database");

                db.SaveChanges();

                Console.WriteLine("Saved to Database");

                CPUCooler cooler1 = new CPUCooler { CPUCoolerID = 1, Name = "Corsair iCUE H150i ELITE LCD XT", Size = "360mm AIO", MaxTDP = 300, Price = 229.99m, Image = "/Images/H150iELITEX.jpg" };
                CPUCooler cooler2 = new CPUCooler { CPUCoolerID = 2, Name = "NZXT Kraken X73 RGB", Size = "360mm AIO", MaxTDP = 280, Price = 199.99m, Image = "/Images/KrakenX73.jpg" };
                CPUCooler cooler3 = new CPUCooler { CPUCoolerID = 3, Name = "ARCTIC Liquid Freezer II 280", Size = "280mm AIO", MaxTDP = 250, Price = 129.99m, Image = "/Images/LiquidFreezer280.png" };
                CPUCooler cooler4 = new CPUCooler { CPUCoolerID = 4, Name = "Noctua NH-D15", Size = "Dual-Tower", MaxTDP = 250, Price = 109.99m, Image = "/Images/NH-D15.jpg" };
                CPUCooler cooler5 = new CPUCooler { CPUCoolerID = 5, Name = "be quiet! Dark Rock Pro 4", Size = "Dual-Tower", MaxTDP = 250, Price = 89.99m, Image = "/Images/DarkRockPro4.jpg" };
                CPUCooler cooler6 = new CPUCooler { CPUCoolerID = 6, Name = "Cooler Master Hyper 212 Black Edition", Size = "Single-Tower", MaxTDP = 180, Price = 49.99m, Image = "/Images/Hyper212Black.jpg" };

                db.CPUCoolers.Add(cooler1);
                db.CPUCoolers.Add(cooler2);
                db.CPUCoolers.Add(cooler3);
                db.CPUCoolers.Add(cooler4);
                db.CPUCoolers.Add(cooler5);
                db.CPUCoolers.Add(cooler6);

                Console.WriteLine("Added Coolers to database");

                db.SaveChanges();

                Console.WriteLine("Saved to Database");

                #endregion

                #region Use if seeding is incorrect
                //Using this to Clear tables after incorrect seeding or changing data

                //using (var context = new PartData())
                //{
                //    try
                //    {
                //        context.Database.ExecuteSqlCommand("DELETE FROM CPUs");

                //        context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('CPUs', RESEED, 0)");

                //        Console.WriteLine("CPU table cleared and identity reseeded.");


                //        context.Database.ExecuteSqlCommand("DELETE FROM Motherboards");

                //        context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Motherboards', RESEED, 0)");

                //        Console.WriteLine("Motherboard table cleared and identity reseeded.");


                //        context.Database.ExecuteSqlCommand("DELETE FROM RAMs");

                //        context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('RAMs', RESEED, 0)");

                //        Console.WriteLine("RAM table cleared and identity reseeded.");


                //        context.Database.ExecuteSqlCommand("DELETE FROM GPUs");

                //        context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('GPUs', RESEED, 0)");

                //        Console.WriteLine("GPU table cleared and identity reseeded.");


                //        context.Database.ExecuteSqlCommand("DELETE FROM PSUs");

                //        context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('PSUs', RESEED, 0)");

                //        Console.WriteLine("PSU table cleared and identity reseeded.");


                //        context.Database.ExecuteSqlCommand("DELETE FROM Cases");

                //        context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Cases', RESEED, 0)");

                //        Console.WriteLine("Case table cleared and identity reseeded.");


                //        context.Database.ExecuteSqlCommand("DELETE FROM Storages");

                //        context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Storages', RESEED, 0)");

                //        Console.WriteLine("Storage table cleared and identity reseeded.");


                //        context.Database.ExecuteSqlCommand("DELETE FROM CPUCoolers");

                //        context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('CPUCoolers', RESEED, 0)");

                //        Console.WriteLine("CPUCooler table cleared and identity reseeded.");

                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine("Error: " + ex.Message);
                //    }
                //}

                //Console.ReadLine();
                #endregion
            }
        }
    }
}
