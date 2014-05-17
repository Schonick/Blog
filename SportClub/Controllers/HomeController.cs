using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportClub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {


            return View();
        }
        public JsonResult GetData()
        {
            // создадим список данных
            List<GeoPlace> stations = new List<GeoPlace>();
            stations.Add(new GeoPlace()
            {
                Id = 1,
                PlaceName = "Спортклуб Спарта",
                GeoLat = 26.971602182525658,

                GeoLong = 49.421021536097655,
                Line = "Сокольническая",
                Traffic = 1.0
            });


            return Json(stations, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Slider()
        {
            ViewBag.Message = "Slider";

            return View();
        }
        public ActionResult Rules()
        {
            return View();
        }
        public ActionResult TicketTest()
        {
            return View();
        }
    }
}
