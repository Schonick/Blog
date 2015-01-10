using SportClub.BlogRepository;
using SportClub.Models;
using SportClub.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportClub.Controllers.BlogControllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/
        IRepository<Post> db;
        public PostController()
        {
            db = new PostRepository();
        }
        public ActionResult Index()
        {
            return View(db.GetList());
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id)
        {

            Post post = db.GetOneObject(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // GET: /Post/Create
        //ModelContext d = new ModelContext();
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(new ModelContext().Categorys, "Id", "Name");
            return View();
        }

        // POST: /Post/Create

        [HttpPost]
        public ActionResult Create(Post post)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    db.Create(post);
                    db.Save();    
                    return RedirectToAction("Index");
                }
                ViewBag.CategoryId = new SelectList(new ModelContext().Categorys, "Id", "Name");
                return View(post);
               
            //}
            //catch
            //{
            //    return View();
            //}
        }

        //
        // GET: /Post/Edit/5
        public ActionResult Edit(int id)
        {
            Post post = db.GetOneObject(id);
            ViewBag.CategoryId = new SelectList(new ModelContext().Categorys, "Id", "Name");
            return View(post);

        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            //try
            //{
            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                db.Update(post);
                db.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(new ModelContext().Categorys, "Id", "Name");
            return View(post);
            //}
            //catch
            //{
            //    return View();
            //}
        }

        //
        // GET: /Post/Delete/5

        public ActionResult Delete(int id)
        {
            Post post = db.GetOneObject(id);
            return View(post);
        }

        //
        // POST: /Post/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
