﻿using MyBookingRoles.Models;
using MyBookingRoles.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookingRoles.Controllers.Stores
{
    [Authorize]
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "SuperAdmin")]
        // GET: Orders
        public ActionResult Index(string searchWord)
        {
            // || p.OrderName.Contains(searchWord)
            return View(db.Orders.Where(p => p.Status.Contains(searchWord) || searchWord == null).ToList());
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public ActionResult ApproveOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //var orderD = db.OrderDetails.Where(o => o.OrderId == id);
            var ord = db.Orders.Find(id);

            if (ord == null)
            {
                return HttpNotFound();
            }
            return View("Index");
        }

        public ActionResult DeleteOrder(int id)
        {
            //write logic for deleting an order with its order details
            return View("Index");
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //var orderD = db.OrderDetails.Where(o => o.OrderId == id);
            var ord = db.Orders.Find(id);
            


            if(ord == null)
            {
                return HttpNotFound();
            }
            return View(ord);
        }

        //// GET: Orders/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Orders/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Orders/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Orders/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Orders/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Orders/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
