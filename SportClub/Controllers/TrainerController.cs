using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportClub.Models;
using System.IO;

namespace SportClub.Controllers
{
    public class TrainerController : Controller
    {
        private ModelContext db = new ModelContext();

        //
        // GET: /Trainer/

        public ActionResult Index()
        {
           
            return View(db.Trainers.ToList());
        }

        //
        // GET: /Trainer/Details/5

        public ActionResult Details(int id = 0)
        {
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        //
        // GET: /Trainer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Trainer/Create

        [HttpPost]
        [Authorize(Users = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase[] file1, Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in file1)
                {
                    if (file == null) continue;
                    UploadTrainerIco(trainer, file);

                    db.Trainers.Add(trainer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(trainer);
        }

        private void UploadTrainerIco(Trainer trainer, HttpPostedFileBase file)
        {
            //string fileName = null;
            var uploadDir = "/Content/avatarku/";
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath(uploadDir) + fileName);
            if (fileName != null) file.SaveAs(path);
            trainer.Image = "/Content/avatarku/" + fileName;
        }

        //
        // GET: /Trainer/Edit/5

        public ActionResult Edit(int? id )
        {
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        //
        // POST: /Trainer/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "admin")]
        public ActionResult Edit(Trainer trainer)
        {
            if (ModelState.IsValid)
            {

                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        //
        // GET: /Trainer/Delete/5
        [Authorize(Users = "admin")]
        public ActionResult Delete(int id = 0)
        {
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        //
        // POST: /Trainer/Delete/5
     
        [HttpPost, ActionName("Delete")]
        [Authorize(Users = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
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