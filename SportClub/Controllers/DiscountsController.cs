using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportClub.Models;

namespace SportClub.Controllers
{
    public class DiscountsController : Controller
    {
        private ModelContext db = new ModelContext();

        //
        // GET: /Discounts/

        public ActionResult Index()
        {
            var discounts = db.Discounts.Include(d => d.PhytobarProduct);
            return View(discounts.ToList());
        }

        //
        // GET: /Discounts/Details/5

        public ActionResult Details(int id = 0)
        {
            Discounts discounts = db.Discounts.Find(id);
            if (discounts == null)
            {
                return HttpNotFound();
            }
            return View(discounts);
        }

        //
        // GET: /Discounts/Create

        public ActionResult Create()
        {
            ViewBag.PhytobarProductsID = new SelectList(db.PhytobarProducts, "PhytobarProductsID", "Products");
            return View();
        }

        //
        // POST: /Discounts/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Discounts discounts)
        {
            if (ModelState.IsValid)
            {
                db.Discounts.Add(discounts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhytobarProductsID = new SelectList(db.PhytobarProducts, "PhytobarProductsID", "Products", discounts.PhytobarProductsID);
            return View(discounts);
        }

        //
        // GET: /Discounts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Discounts discounts = db.Discounts.Find(id);
            if (discounts == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhytobarProductsID = new SelectList(db.PhytobarProducts, "PhytobarProductsID", "Products", discounts.PhytobarProductsID);
            return View(discounts);
        }

        //
        // POST: /Discounts/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Discounts discounts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhytobarProductsID = new SelectList(db.PhytobarProducts, "PhytobarProductsID", "Products", discounts.PhytobarProductsID);
            return View(discounts);
        }

        //
        // GET: /Discounts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Discounts discounts = db.Discounts.Find(id);
            if (discounts == null)
            {
                return HttpNotFound();
            }
            return View(discounts);
        }

        //
        // POST: /Discounts/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Discounts discounts = db.Discounts.Find(id);
            db.Discounts.Remove(discounts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}