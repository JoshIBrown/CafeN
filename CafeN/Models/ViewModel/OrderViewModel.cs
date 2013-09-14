using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CafeN.Models.ViewModel
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }

        public int UserID { get; set; }

        public int LocationID { get; set; }

        [Display(Name = "Ordered")]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Due")]
        public DateTime? PickUpAt { get; set; }

        public DateTime? CancelledAt { get; set; }

        [Display(Name = "Started")]
        public DateTime? StartedAt { get; set; }

        [Display(Name = "Completed")]
        public DateTime? CompletedAt { get; set; }

        [Display(Name = "Customer")]
        public string UserName { get; set; }
    }
}