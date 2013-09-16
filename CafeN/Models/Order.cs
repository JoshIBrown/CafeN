using System;
using System.ComponentModel.DataAnnotations;

namespace CafeN.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int LocationID { get; set; }
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime CreatedAt { get; set; }
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime? PickUpAt { get; set; }
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime? CancelledAt { get; set; }
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime? StartedAt { get; set; }
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime? CompletedAt { get; set; }
    }
}