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
    [Authorize]
    public class VisitsController : Controller
    {
        private ModelContext db = new ModelContext();

        //
        // GET: /Visits/

        public ActionResult Index()
        {
            var visits = db.Visits.Include(v => v.Client).Include(v => v.SportHalls);
            return View(visits.ToList());
        }

        //
        // GET: /Visits/Details/5

        public ActionResult Details(int id = 0)
        {
            Visits visits = db.Visits.Find(id);
            if (visits == null)
            {
                return HttpNotFound();
            }
            return View(visits);
        }

        //
        // GET: /Visits/Create

        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "FName");
            ViewBag.SportHallID = new SelectList(db.SportHalls, "SportHallID", "Name");
            return View();
        }

        //
        // POST: /Visits/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Visits visits)
        {
            if (ModelState.IsValid)
            {
                db.Visits.Add(visits);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "FName", visits.ClientID);
            ViewBag.SportHallID = new SelectList(db.SportHalls, "SportHallID", "Name", visits.SportHallID);
            return View(visits);
        }

        //
        // GET: /Visits/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Visits visits = db.Visits.Find(id);
            if (visits == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "FName", visits.ClientID);
            ViewBag.SportHallID = new SelectList(db.SportHalls, "SportHallID", "Name", visits.SportHallID);
            return View(visits);
        }

        //
        // POST: /Visits/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Visits visits)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visits).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "FName", visits.ClientID);
            ViewBag.SportHallID = new SelectList(db.SportHalls, "SportHallID", "Name", visits.SportHallID);
            return View(visits);
        }

        //
        // GET: /Visits/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Visits visits = db.Visits.Find(id);
            if (visits == null)
            {
                return HttpNotFound();
            }
            return View(visits);
        }

        //
        // POST: /Visits/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visits visits = db.Visits.Find(id);
            db.Visits.Remove(visits);
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