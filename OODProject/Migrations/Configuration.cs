namespace OODProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OODProject.PartData>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OODProject.PartData";
        }

        protected override void Seed(OODProject.PartData context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
