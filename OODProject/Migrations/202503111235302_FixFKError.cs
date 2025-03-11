namespace OODProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixFKError : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CPUs", "CPUCoolerID", "dbo.CPUCoolers");
            DropIndex("dbo.CPUs", new[] { "CPUCoolerID" });
            AlterColumn("dbo.CPUs", "CPUCoolerID", c => c.Int());
            CreateIndex("dbo.CPUs", "CPUCoolerID");
            AddForeignKey("dbo.CPUs", "CPUCoolerID", "dbo.CPUCoolers", "CPUCoolerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CPUs", "CPUCoolerID", "dbo.CPUCoolers");
            DropIndex("dbo.CPUs", new[] { "CPUCoolerID" });
            AlterColumn("dbo.CPUs", "CPUCoolerID", c => c.Int(nullable: false));
            CreateIndex("dbo.CPUs", "CPUCoolerID");
            AddForeignKey("dbo.CPUs", "CPUCoolerID", "dbo.CPUCoolers", "CPUCoolerID", cascadeDelete: true);
        }
    }
}
