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
    public class AccountingController : Controller
    {
        private ModelContext db = new ModelContext();

        //
        // GET: /Accounting/

        public ActionResult Index()
        {
            var accountings = db.Accountings.Include(a => a.Client).Include(a => a.Ticket);
            return View(accountings.ToList());
        }

        //
        // GET: /Accounting/Details/5

        public ActionResult Details(int id = 0)
        {
            Accounting accounting = db.Accountings.Find(id);
            if (accounting == null)
            {
                return HttpNotFound();
            }
            return View(accounting);
        }

        //
        // GET: /Accounting/Create

        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "FName");
            ViewBag.TicketID = new SelectList(db.Tickets, "TicketID", "NameTicket");
            return View();
        }

        //
        // POST: /Accounting/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Accounting accounting)
        {
            if (ModelState.IsValid)
            {
                db.Accountings.Add(accounting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "FName", accounting.ClientID);
            ViewBag.TicketID = new SelectList(db.Tickets, "TicketID", "NameTicket", accounting.TicketID);
            return View(accounting);
        }

        //
        // GET: /Accounting/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Accounting accounting = db.Accountings.Find(id);
            if (accounting == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "FName", accounting.ClientID);
            ViewBag.TicketID = new SelectList(db.Tickets, "TicketID", "NameTicket", accounting.TicketID);
            return View(accounting);
        }

        //
        // POST: /Accounting/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Accounting accounting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accounting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "FName", accounting.ClientID);
            ViewBag.TicketID = new SelectList(db.Tickets, "TicketID", "NameTicket", accounting.TicketID);
            return View(accounting);
        }

        //
        // GET: /Accounting/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Accounting accounting = db.Accountings.Find(id);
            if (accounting == null)
            {
                return HttpNotFound();
            }
            return View(accounting);
        }

        //
        // POST: /Accounting/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accounting accounting = db.Accountings.Find(id);
            db.Accountings.Remove(accounting);
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