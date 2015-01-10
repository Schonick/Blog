using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportClub.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Return view for 404 errors.
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFound()
        {
            return View();
        }

    }
}
