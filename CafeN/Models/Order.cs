using System;

namespace CafeN.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int LocationID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PickUpAt { get; set; }
        public DateTime? CancelledAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}