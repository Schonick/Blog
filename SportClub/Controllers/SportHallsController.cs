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
    public class SportHallsController : Controller
    {
        private ModelContext db = new ModelContext();

        //
        // GET: /SportHalls/

        public ActionResult Index()
        {
            return View(db.SportHalls.ToList());
        }

        //
        // GET: /SportHalls/Details/5

        public ActionResult Details(int id = 0)
        {
            SportHalls sporthalls = db.SportHalls.Find(id);
            if (sporthalls == null)
            {
                return HttpNotFound();
            }
            return View(sporthalls);
        }

        //
        // GET: /SportHalls/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SportHalls/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SportHalls sporthalls)
        {
            if (ModelState.IsValid)
            {
                db.SportHalls.Add(sporthalls);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sporthalls);
        }

        //
        // GET: /SportHalls/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SportHalls sporthalls = db.SportHalls.Find(id);
            if (sporthalls == null)
            {
                return HttpNotFound();
            }
            return View(sporthalls);
        }

        //
        // POST: /SportHalls/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SportHalls sporthalls)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sporthalls).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sporthalls);
        }

        //
        // GET: /SportHalls/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SportHalls sporthalls = db.SportHalls.Find(id);
            if (sporthalls == null)
            {
                return HttpNotFound();
            }
            return View(sporthalls);
        }

        //
        // POST: /SportHalls/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SportHalls sporthalls = db.SportHalls.Find(id);
            db.SportHalls.Remove(sporthalls);
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