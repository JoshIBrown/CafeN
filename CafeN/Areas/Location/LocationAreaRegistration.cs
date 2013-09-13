﻿using System.Web.Mvc;

namespace CafeN.Areas.Location
{
    public class LocationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Location";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Location_default",
                "Location/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }, new { controller=@"Order" }
            );
        }
    }
}