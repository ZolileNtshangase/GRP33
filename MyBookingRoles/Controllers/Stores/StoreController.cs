using MyBookingRoles.Models;
using MyBookingRoles.Models.Store;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Studio45.Controllers.Store
{

    public class StoreController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StoreHome

        public ActionResult ProdCatalogue(string searchWord)
        {
            return View(db.Products.Where(p => p.ProductName.Contains(searchWord) || searchWord == null && p.IsVisible == true).ToList());
        }

        public ActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        //GET:/StoreHome/Browse
        public ActionResult Search()
        {
            //Search Code....
            //

            return View("ProdCatalogue");
        }

        public ActionResult BrandCatalogue(string searchWord)
        {
            return View(db.Brands.Where(p => p.Name.Contains(searchWord) || searchWord == null).ToList());
        }

        public ActionResult CategoryCatalogue(string searchWordC)
        {
            return View(db.Category.Where(p => p.CategoryName.Contains(searchWordC) || searchWordC == null).ToList());
        }
    }
}