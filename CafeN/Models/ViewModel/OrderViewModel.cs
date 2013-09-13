using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeN.Models.ViewModel
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int LocationID { get; set; }
        //public string Size;
        //public string Bean;
        //public string Type;
        public DateTime? CreatedAt { get; set; }
        public DateTime? PickUpAt { get; set; }
        public DateTime? CancelledAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string LocationName { get; set; }
    }
}