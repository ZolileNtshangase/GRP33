using MyBookingRoles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookingRoles.Controllers.Delivery
{
    [Authorize(Roles = "Delivery")]
    public class DeliverySystemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult DeliverySystemDashBoard()
        {
            return View();
        }

        //public ActionResult ApprovedOrders()
        //{
        //    return View(db.Orders.OrderByDescending(x => x.OrderId && x.Status == "").ToList());
        //}

    }
}