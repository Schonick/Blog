using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportClub.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Contact()
        {
            Contact model = new Contact();
            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(Contact model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Email e = new Email();
            e.Send(model);

            return View("ContactSuccess");
        }

    }
}
