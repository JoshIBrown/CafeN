using CafeN.Models;
using CafeN.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace CafeN.Areas.Location.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Location/Order/

        public ActionResult Index()
        {
            IEnumerable<Order> orders;

            using (CafeContext context = new CafeContext())
            {
                int userID = WebSecurity.GetUserId(User.Identity.Name);
                orders = context.Orders.Where(o => o.UserID == userID).ToList();
            }

            return View(orders);
        }

        [Authorize(Roles="Barista")]
        public ActionResult Process(int id)
        {
            IEnumerable<OrderViewModel> orders;

            using (CafeContext context = new CafeContext())
            {
                //fill in parameters to copy order to orderviewmodel including location name
                orders = context.Orders.Where(o => o.LocationID == id).Select(o => new OrderViewModel {  }).ToList();
            }

            return View(orders);
        }


        //
        // GET: /Location/Order/Create
        [Authorize]
        public ActionResult Create(int id)
        {
            OrderViewModel o = new OrderViewModel { LocationID = id };

            return View(o);
        }

        //
        // POST: /Location/Order/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel order)
        {
            using (CafeContext db = new CafeContext())
            {
                if (ModelState.IsValid)
                {
                    Order toAdd = new Order { LocationID = order.LocationID, PickUpAt = order.PickUpAt, CreatedAt = DateTime.Now, UserID = WebSecurity.GetUserId(User.Identity.Name) };

                    db.Orders.Add(toAdd);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(order);
        }
    }
}
