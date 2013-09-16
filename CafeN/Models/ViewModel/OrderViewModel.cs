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

        [Display(Name = "Cafe")]
        public string LocationName { get; set; }

        [Display(Name = "Ordered")]
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Pickup Time")]
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime? PickUpAt { get; set; }

        [Display(Name = "Cancelled")]
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime? CancelledAt { get; set; }

        [Display(Name = "Started")]
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime? StartedAt { get; set; }

        [Display(Name = "Completed")]
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime? CompletedAt { get; set; }

        [Display(Name = "Customer")]
        [DisplayFormat(DataFormatString = "{0:t}")]
        public string UserName { get; set; }
    }
}
