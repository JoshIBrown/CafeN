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
        public ActionResult Complete(int id)
        {
            using (CafeContext context = new CafeContext())
            {
                Order toStart = context.Orders.Single(order => order.OrderID == id);
                toStart.CompletedAt = DateTime.Now;
                context.SaveChanges();

                ViewBag.UserName = context.UserProfiles.FirstOrDefault(user => user.UserId == toStart.UserID).UserName;

                return View(OrderToViewModel(toStart));
            }
        }
        
        public ActionResult Start(int id)
        {
            using (CafeContext context = new CafeContext())
            {
                Order toStart = context.Orders.Single(order => order.OrderID == id);
                toStart.StartedAt = DateTime.Now;
                context.SaveChanges();

                ViewBag.UserName = context.UserProfiles.FirstOrDefault(user => user.UserId == toStart.UserID).UserName;

                return View(OrderToViewModel(toStart));
            }
        }

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

        [Authorize(Roles = "Barista")]
        public ActionResult Process(int id)
        {
            IEnumerable<OrderViewModel> orders;
            using (CafeContext context = new CafeContext())
            {
                //set location name
                ViewBag.LocationName = context.Locations.FirstOrDefault(loc => loc.LocationID == id).Name;

                orders = context.Orders.Where(o => o.LocationID == id).Select(ovm => new OrderViewModel()
                {
                    CancelledAt = ovm.CancelledAt,
                    CompletedAt = ovm.CompletedAt,
                    CreatedAt = ovm.CreatedAt,
                    LocationID = ovm.LocationID,
                    OrderID = ovm.OrderID,
                    PickUpAt = ovm.PickUpAt,
                    StartedAt = ovm.StartedAt,
                    UserID = ovm.UserID,
                    UserName = context.UserProfiles.FirstOrDefault(user => user.UserId == ovm.UserID).UserName
                }).ToList().OrderBy(order => order.PickUpAt);
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
            using (CafeContext context = new CafeContext())
            {
                if (ModelState.IsValid)
                {
                    Order toAdd = new Order { LocationID = order.LocationID, PickUpAt = order.PickUpAt, CreatedAt = DateTime.Now, UserID = WebSecurity.GetUserId(User.Identity.Name) };

                    context.Orders.Add(toAdd);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(order);
        }

        public OrderViewModel OrderToViewModel(Order order)
        {
            OrderViewModel ovm = new OrderViewModel()
                {
                    CancelledAt = order.CancelledAt,
                    CompletedAt = order.CompletedAt,
                    CreatedAt = order.CreatedAt,
                    LocationID = order.LocationID,
                    OrderID = order.OrderID,
                    PickUpAt = order.PickUpAt,
                    StartedAt = order.StartedAt,
                    UserID = order.UserID
                };

            return ovm;
        }
    }
}
