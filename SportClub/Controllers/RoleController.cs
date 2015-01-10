using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;


namespace SportClub.Controllers
{
    public class RoleController : Controller
    {
       
        // GET: /Role/

        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var roles = Roles.GetAllRoles();
            return View(roles);
        }
        public ActionResult RoleCreate()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleCreate(string RoleName)
        {
            Roles.CreateRole(Request.Form["RoleName"]);
            // ViewBag.ResultMessage = "Role created successfully !";

            return RedirectToAction("Index", "Role");
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult RoleDelete(string RoleName)
        {
            Roles.DeleteRole(RoleName);
            // ViewBag.ResultMessage = "Role deleted succesfully !";
            return RedirectToAction("Index", "Role");
        }
        /// <summary>
        /// Create a new role to the user
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        public ActionResult RoleAddToUser()
        {
            SelectList list = new SelectList(Roles.GetAllRoles());
            ViewBag.Roles = list;

            return View();
        }

        /// <summary>
        /// Add role to the user
        /// </summary>
        /// <param name="RoleName"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string RoleName, string UserName)
        {
            if (Roles.IsUserInRole(UserName, RoleName))
            {
                ViewBag.ResultMessage = "Пользователь уже имеет указанная роль !";
            }
            else
            {
                Roles.AddUserToRole(UserName, RoleName);
                ViewBag.ResultMessage = "Имя пользователя успешно добавляется к роли !";
            }
            SelectList list = new SelectList(Roles.GetAllRoles());
            ViewBag.Roles = list;
            return View();
        }

        /// <summary>
        /// Get all the roles for a particular user
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ViewBag.RolesForThisUser = Roles.GetRolesForUser(UserName);
                SelectList list = new SelectList(Roles.GetAllRoles());
                ViewBag.Roles = list;
            }
            return View("RoleAddToUser");
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {

            if (Roles.IsUserInRole(UserName, RoleName))
            {
                Roles.RemoveUserFromRole(UserName, RoleName);
                ViewBag.ResultMessage = "Роль удалена для этого пользователя успешно !";
            }
            else
            {
                ViewBag.ResultMessage = "Этоь пользователь не принадлежат к выбранной роли.";
            }
            ViewBag.RolesForThisUser = Roles.GetRolesForUser(UserName);
            SelectList list = new SelectList(Roles.GetAllRoles());
            ViewBag.Roles = list;
            return View("RoleAddToUser");
        }
    }
}
