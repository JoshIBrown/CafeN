using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


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
    }

    public class Location
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class Order
    {
        public Order()
        {
            
        }

        public Order(int LocationID)
        {
            this.LocationID = LocationID;
        }

        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int LocationID { get; set; }
        public string Size;
        public string Bean;
        public string Type;
        public DateTime CreatedAt { get; set; }
        public DateTime PickUpAt { get; set; }
        public DateTime CancelledAt { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime CompletedAt { get; set; }
    }
}