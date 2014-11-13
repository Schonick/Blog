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
    public class PhytobarProductsController : Controller
    {
        private ModelContext db = new ModelContext();

        //
        // GET: /PhytobarProducts/

        public ActionResult Index()
        {
            var phytobarproducts = db.PhytobarProducts.Include(p => p.Discounts);
            return View(phytobarproducts.ToList());
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
            ViewBag.DiscountsID = new SelectList(db.Discounts, "DiscountsID", "Comment");
            return View();
        }

        //
        // POST: /PhytobarProducts/Create

        [HttpPost]
        [Authorize(Users = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase[] file1, PhytobarProducts phytobarproducts)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in file1)
                {
                    if (file == null) continue;
                    UploadTrainerIco(phytobarproducts, file);
                    db.PhytobarProducts.Add(phytobarproducts);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.DiscountsID = new SelectList(db.Discounts, "DiscountsID", "Comment", phytobarproducts.DiscountsID);
            return View(phytobarproducts);
        }

        private void UploadTrainerIco(PhytobarProducts phytobarproducts, HttpPostedFileBase file)
        {
            //string fileName = null;
            var uploadDir = "/Content/product/";
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath(uploadDir) + fileName);
            if (fileName != null) file.SaveAs(path);
            phytobarproducts.Image = "/Content/product/" + fileName;
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
            ViewBag.DiscountsID = new SelectList(db.Discounts, "DiscountsID", "Comment", phytobarproducts.DiscountsID);
            return View(phytobarproducts);
        }

        //
        // POST: /PhytobarProducts/Edit/5

        [HttpPost]
        [Authorize(Users = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhytobarProducts phytobarproducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phytobarproducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiscountsID = new SelectList(db.Discounts, "DiscountsID", "Comment", phytobarproducts.DiscountsID);
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
        [Authorize(Users = "admin")]
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