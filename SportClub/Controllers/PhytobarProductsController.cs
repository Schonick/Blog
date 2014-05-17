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
    public class PhytobarProductsController : Controller
    {
        private ModelContext db = new ModelContext();

        //
        // GET: /PhytobarProducts/

        public ActionResult Index()
        {
            return View(db.PhytobarProducts.ToList());
        }

        //
        // GET: /PhytobarProducts/Details/5

        public ActionResult Details(int id = 0)
        {
            PhytobarProducts phytobarproducts = db.PhytobarProducts.Find(id);
            if (phytobarproducts == null)
            {
                return HttpNotFound();
            }
            return View(phytobarproducts);
        }

        //
        // GET: /PhytobarProducts/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PhytobarProducts/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhytobarProducts phytobarproducts)
        {
            if (ModelState.IsValid)
            {
                db.PhytobarProducts.Add(phytobarproducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phytobarproducts);
        }

        //
        // GET: /PhytobarProducts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PhytobarProducts phytobarproducts = db.PhytobarProducts.Find(id);
            if (phytobarproducts == null)
            {
                return HttpNotFound();
            }
            return View(phytobarproducts);
        }

        //
        // POST: /PhytobarProducts/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhytobarProducts phytobarproducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phytobarproducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phytobarproducts);
        }

        //
        // GET: /PhytobarProducts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PhytobarProducts phytobarproducts = db.PhytobarProducts.Find(id);
            if (phytobarproducts == null)
            {
                return HttpNotFound();
            }
            return View(phytobarproducts);
        }

        //
        // POST: /PhytobarProducts/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhytobarProducts phytobarproducts = db.PhytobarProducts.Find(id);
            db.PhytobarProducts.Remove(phytobarproducts);
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