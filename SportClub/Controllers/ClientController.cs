using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportClub.Models;
using System.IO;
using PagedList;

namespace SportClub.Controllers
{
    [Authorize(Users = "admin")]
    public class ClientController : Controller
    { 
        private ModelContext db = new ModelContext();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var client = from s in db.Clients
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                client = client.Where(s => s.LName.ToUpper().Contains(searchString.ToUpper())
                                       || s.FName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    client = client.OrderByDescending(s => s.LName);
                    break;
                case "Date":
                    client = client.OrderBy(s => s.Data);
                    break;
                case "date_desc":
                    client = client.OrderByDescending(s => s.Data);
                    break;

                default:  // Name ascending 
                    client = client.OrderBy(s => s.LName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            var clients = db.Clients.Include(c => c.Trainer);
            return View( clients.ToList().ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Client/Details/5

        public ActionResult Details(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // GET: /Client/Create

        public ActionResult Create()
        {
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "FName");
            return View();
        }

        //
        // POST: /Client/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase[] file1, Client client)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in file1)
                {
                    if (file == null) continue;
                    var uploadDir = "/Content/avatarku/";
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath(uploadDir) + fileName);
                    if (fileName != null) file.SaveAs(path);
                    client.foto = "/Content/avatarku/" + fileName;
                    db.Clients.Add(client);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "FName", client.TrainerID);
            return View(client);

        }

        // GET: /Client/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "FName", client.TrainerID);
            return View(client);
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "FName", client.TrainerID);
            return View(client);
        }

        //
        // GET: /Client/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // POST: /Client/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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