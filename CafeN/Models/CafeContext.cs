using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CafeN.Models
{
    public class CafeContext : DbContext
    {
        public CafeContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }


    public class CafeContextInitializer : DropCreateDatabaseAlways<CafeContext>
    {
        protected override void Seed(CafeContext context)
        {
            if (context.Locations.Count() == 0)
            {
                context.Locations.Add(new Location { Name = "Cafe 1", Address = "1st & University", City = "Seattle", State = "WA", Zip = "98101" });
                context.Locations.Add(new Location { Name = "Cafe 2", Address = "2nd & Union", City = "Seattle", State = "WA", Zip = "98101" });
                context.Locations.Add(new Location { Name = "Cafe 3", Address = "3rd & Seneca", City = "Seattle", State = "WA", Zip = "98101" });
                context.Locations.Add(new Location { Name = "Cafe 4", Address = "4th & Madison", City = "Seattle", State = "WA", Zip = "98101" });
            }

            base.Seed(context);
        }
    }
}