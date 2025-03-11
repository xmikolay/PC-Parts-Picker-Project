namespace OODProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedMotherboardClassandCaseClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GPUs", "Case_CaseID", "dbo.Cases");
            DropForeignKey("dbo.GPUs", "Motherboard_MotherboardID", "dbo.Motherboards");
            DropIndex("dbo.GPUs", new[] { "Case_CaseID" });
            DropIndex("dbo.GPUs", new[] { "Motherboard_MotherboardID" });
            DropColumn("dbo.GPUs", "Case_CaseID");
            DropColumn("dbo.GPUs", "Motherboard_MotherboardID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GPUs", "Motherboard_MotherboardID", c => c.Int());
            AddColumn("dbo.GPUs", "Case_CaseID", c => c.Int());
            CreateIndex("dbo.GPUs", "Motherboard_MotherboardID");
            CreateIndex("dbo.GPUs", "Case_CaseID");
            AddForeignKey("dbo.GPUs", "Motherboard_MotherboardID", "dbo.Motherboards", "MotherboardID");
            AddForeignKey("dbo.GPUs", "Case_CaseID", "dbo.Cases", "CaseID");
        }
    }
}
