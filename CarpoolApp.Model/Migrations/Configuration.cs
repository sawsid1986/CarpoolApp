namespace CarpoolApp.Model.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarpoolApp.Model.DbContexts.CarpoolModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CarpoolApp.Model.DbContexts.CarpoolModel";
        }

        protected override void Seed(CarpoolApp.Model.DbContexts.CarpoolModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Locations.AddOrUpdate(
              p => p.Name,
              new Location { Name = "Hinjawadi Phase 3", City = "Pune", IsActive = true },
              new Location { Name = "Hinjawadi Phase 2", City = "Pune", IsActive = true },
              new Location { Name = "Hinjawadi Phase 1", City = "Pune", IsActive = true },
              new Location { Name = "Pimple Saudagar", City = "Pune", IsActive = true }
            );

            context.Statuses.AddOrUpdate(s => s.Name,
                new Status { Name="New",IsActive=true },
                new Status { Name = "Full", IsActive = true },
                new Status { Name = "Closed", IsActive = true },
                new Status { Name = "Requested", IsActive = true },
                new Status { Name = "Accepted", IsActive = true }
            );
            //
        }
    }
}
