using SertzHir.Core.Entities;

namespace SertzHir.Services.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SertzHir.Services.SertzHirDataDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SertzHir.Services.SertzHirDataDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.States.AddOrUpdate(x => x.StateId,
                new State() { StateCode = "AL" },
                new State() { StateCode = "AK" },
                new State() { StateCode = "AZ" },
                new State() { StateCode = "AR" },
                new State() { StateCode = "CA" },
                new State() { StateCode = "CO" },
                new State() { StateCode = "CT" },
                new State() { StateCode = "DE" },
                new State() { StateCode = "DC" },
                new State() { StateCode = "FL" },
                new State() { StateCode = "GA" },
                new State() { StateCode = "HI" },
                new State() { StateCode = "ID" },
                new State() { StateCode = "IL" },
                new State() { StateCode = "IN" },
                new State() { StateCode = "IA" },
                new State() { StateCode = "KS" },
                new State() { StateCode = "KY" },
                new State() { StateCode = "LA" },
                new State() { StateCode = "ME" },
                new State() { StateCode = "MD" },
                new State() { StateCode = "MA" },
                new State() { StateCode = "MI" },
                new State() { StateCode = "MN" },
                new State() { StateCode = "MS" },
                new State() { StateCode = "MO" },
                new State() { StateCode = "MT" },
                new State() { StateCode = "NE" },
                new State() { StateCode = "NV" },
                new State() { StateCode = "NM" },
                new State() { StateCode = "NH" },
                new State() { StateCode = "NY" },
                new State() { StateCode = "NC" },
                new State() { StateCode = "ND" },
                new State() { StateCode = "OH" },
                new State() { StateCode = "OK" },
                new State() { StateCode = "OR" },
                new State() { StateCode = "PA" },
                new State() { StateCode = "RI" },
                new State() { StateCode = "SC" },
                new State() { StateCode = "SD" },
                new State() { StateCode = "TN" },
                new State() { StateCode = "TX" },
                new State() { StateCode = "UT" },
                new State() { StateCode = "VT" },
                new State() { StateCode = "VA" },
                new State() { StateCode = "WA" },
                new State() { StateCode = "WV" },
                new State() { StateCode = "WV" },
                new State() { StateCode = "WI" },
                new State() { StateCode = "WY" },
                new State() { StateCode = "PR" }
            );
        }
    }
}
