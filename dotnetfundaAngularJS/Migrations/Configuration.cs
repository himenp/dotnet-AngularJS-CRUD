namespace dotnetfundaAngularJS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<dotnetfundaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(dotnetfundaDbContext context)
        {
            //  This method will be called after migrating to the latest version.

              //You can use the DbSet<T>.AddOrUpdate() helper extension method 
              //to avoid creating duplicate seed data. E.g.
            
                context.tags.AddOrUpdate(
                  p => p.Tag,
                  new Tags { Tag = "ASP.NET MVC" },
                  new Tags { Tag = "C#" },
                  new Tags { Tag = "AngularJS" },
                  new Tags { Tag = "JQuery" },
                  new Tags { Tag = "WCF" },
                  new Tags { Tag = "SQL Server" }
                );
            
        }
    }
}
