using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportClub.Models;
using System.Web.Security;
using WebMatrix.WebData;

namespace SportClub.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        ModelContext db = new ModelContext();
        public ActionResult Index()
        {
            var users = db.UserProfiles.ToList();

            return View(users);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserProfile user)
        {
            if (ModelState.IsValid)
            {
                WebSecurity.CreateUserAndAccount(user.UserName, "1111");
                Roles.AddUsersToRole(new[] { user.UserName }, "User");           
                return RedirectToAction("Index");
            }
            //HttpContext.User.IsInRole("admin");

            SelectList roles = new SelectList(Roles.GetAllRoles(), "RoleId", "RoleName", user.UserId);
            ViewBag.Roles = roles;

            return View(user);
        }
        public ActionResult Delete(int id)
        {
            UserProfile user = db.UserProfiles.Find(id);
            db.UserProfiles.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
