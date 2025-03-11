namespace OODProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedGPUClassAndPSUClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GPUs", "RequiredPSU_PsuID", "dbo.PSUs");
            DropIndex("dbo.GPUs", new[] { "RequiredPSU_PsuID" });
            AddColumn("dbo.GPUs", "PSURequirement", c => c.Int(nullable: false));
            DropColumn("dbo.GPUs", "PSURequirementID");
            DropColumn("dbo.GPUs", "RequiredPSU_PsuID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GPUs", "RequiredPSU_PsuID", c => c.Int());
            AddColumn("dbo.GPUs", "PSURequirementID", c => c.Int(nullable: false));
            DropColumn("dbo.GPUs", "PSURequirement");
            CreateIndex("dbo.GPUs", "RequiredPSU_PsuID");
            AddForeignKey("dbo.GPUs", "RequiredPSU_PsuID", "dbo.PSUs", "PsuID");
        }
    }
}
