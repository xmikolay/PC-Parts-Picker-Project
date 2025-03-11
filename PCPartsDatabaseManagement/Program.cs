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

                Motherboard mb1 = new Motherboard { MotherboardID = 1, Name = "MSI MAG Z890 Tomahawk WIFI", Platform = "LGA1851", Chipset = "Z890", MaxMemoryCapacity = 256, MemorySlots = 4, FormFactor = "ATX", Price = 365.00m, Image = "", MemoryType = "DDR5" };
                Motherboard mb2 = new Motherboard { MotherboardID = 2, Name = "Gigabyte Z890M Gaming X", Platform = "LGA1851", Chipset = "Z890", MaxMemoryCapacity = 256, MemorySlots = 4, FormFactor = "MATX", Price = 230.00m, Image = "", MemoryType = "DDR5" };
                Motherboard mb3 = new Motherboard { MotherboardID = 3, Name = "MSI B760 GAMING PLUS WIFI", Platform = "LGA1700", Chipset = "B760", MaxMemoryCapacity = 256, MemorySlots = 4, FormFactor = "ATX", Price = 180.00m, Image = "", MemoryType = "DDR5" };
                Motherboard mb4 = new Motherboard { MotherboardID = 4, Name = "ASUS ROG Crosshair X870E Hero", Platform = "AM5", Chipset = "X870E", MaxMemoryCapacity = 256, MemorySlots = 4, FormFactor = "ATX", Price = 740.99m, Image = "", MemoryType = "DDR5" };
                Motherboard mb5 = new Motherboard { MotherboardID = 5, Name = "ASUS TUF GAMING B650-PLUS WIFI", Platform = "AM5", Chipset = "B650", MaxMemoryCapacity = 128, MemorySlots = 4, FormFactor = "ATX", Price = 179.99m, Image = "", MemoryType = "DDR5" };
                Motherboard mb6 = new Motherboard { MotherboardID = 6, Name = "MSI MPG B550 GAMING CARBON WIFI", Platform = "AM4", Chipset = "B550", MaxMemoryCapacity = 128, MemorySlots = 4, FormFactor = "ATX", Price = 140.00m, Image = "", MemoryType = "DDR4" };

            }


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
