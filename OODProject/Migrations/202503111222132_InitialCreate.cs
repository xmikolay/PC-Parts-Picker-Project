namespace OODProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        CaseID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FormFactor = c.String(),
                        MaxGPULength = c.Int(nullable: false),
                        MaxCoolerHeight = c.Int(nullable: false),
                        FansIncluded = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.CaseID);
            
            CreateTable(
                "dbo.GPUs",
                c => new
                    {
                        GpuID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MemoryType = c.String(),
                        MemorySize = c.Int(nullable: false),
                        TDP = c.Int(nullable: false),
                        Interface = c.String(),
                        ExternalPower = c.String(),
                        GPULength = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        PSURequirementID = c.Int(nullable: false),
                        RequiredPSU_PsuID = c.Int(),
                        Case_CaseID = c.Int(),
                        Motherboard_MotherboardID = c.Int(),
                    })
                .PrimaryKey(t => t.GpuID)
                .ForeignKey("dbo.PSUs", t => t.RequiredPSU_PsuID)
                .ForeignKey("dbo.Cases", t => t.Case_CaseID)
                .ForeignKey("dbo.Motherboards", t => t.Motherboard_MotherboardID)
                .Index(t => t.RequiredPSU_PsuID)
                .Index(t => t.Case_CaseID)
                .Index(t => t.Motherboard_MotherboardID);
            
            CreateTable(
                "dbo.PSUs",
                c => new
                    {
                        PsuID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Wattage = c.Int(nullable: false),
                        Size = c.String(),
                        Efficiency = c.String(),
                        Modularity = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.PsuID);
            
            CreateTable(
                "dbo.CPUCoolers",
                c => new
                    {
                        CPUCoolerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Size = c.String(),
                        MaxTDP = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.CPUCoolerID);
            
            CreateTable(
                "dbo.CPUs",
                c => new
                    {
                        CpuID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Platform = c.String(),
                        Cores = c.Int(nullable: false),
                        Threads = c.Int(nullable: false),
                        BaseClock = c.Double(nullable: false),
                        BoostClock = c.Double(nullable: false),
                        Architecture = c.String(),
                        TDP = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        IncludesCooler = c.Boolean(nullable: false),
                        CPUCoolerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CpuID)
                .ForeignKey("dbo.CPUCoolers", t => t.CPUCoolerID, cascadeDelete: true)
                .Index(t => t.CPUCoolerID);
            
            CreateTable(
                "dbo.GenericParts",
                c => new
                    {
                        GenericPartID = c.Int(nullable: false, identity: true),
                        PartName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.GenericPartID);
            
            CreateTable(
                "dbo.Motherboards",
                c => new
                    {
                        MotherboardID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Platform = c.String(),
                        Chipset = c.String(),
                        MaxMemoryCapacity = c.Int(nullable: false),
                        MemorySlots = c.Int(nullable: false),
                        FormFactor = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        MemoryType = c.String(),
                    })
                .PrimaryKey(t => t.MotherboardID);
            
            CreateTable(
                "dbo.RAMs",
                c => new
                    {
                        RamID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RAMType = c.String(),
                        Modules = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Speed = c.Int(nullable: false),
                        CASLatency = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.RamID);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        StorageID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Capacity = c.Int(nullable: false),
                        Interface = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.StorageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GPUs", "Motherboard_MotherboardID", "dbo.Motherboards");
            DropForeignKey("dbo.CPUs", "CPUCoolerID", "dbo.CPUCoolers");
            DropForeignKey("dbo.GPUs", "Case_CaseID", "dbo.Cases");
            DropForeignKey("dbo.GPUs", "RequiredPSU_PsuID", "dbo.PSUs");
            DropIndex("dbo.CPUs", new[] { "CPUCoolerID" });
            DropIndex("dbo.GPUs", new[] { "Motherboard_MotherboardID" });
            DropIndex("dbo.GPUs", new[] { "Case_CaseID" });
            DropIndex("dbo.GPUs", new[] { "RequiredPSU_PsuID" });
            DropTable("dbo.Storages");
            DropTable("dbo.RAMs");
            DropTable("dbo.Motherboards");
            DropTable("dbo.GenericParts");
            DropTable("dbo.CPUs");
            DropTable("dbo.CPUCoolers");
            DropTable("dbo.PSUs");
            DropTable("dbo.GPUs");
            DropTable("dbo.Cases");
        }
    }
}
