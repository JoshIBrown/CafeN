using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CafeN.Models;
using WebMatrix.WebData;

namespace CafeN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Location");
            }

            return View();
        }

        public ActionResult Barista()
        {
            return View();
        }

    }
}
