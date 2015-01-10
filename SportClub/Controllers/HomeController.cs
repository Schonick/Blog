using SportClub.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleChart = System.Web.Helpers;

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
        public ActionResult Price()
        {
            return View();
        }

        #region Chart
        //Chart
        public ActionResult Chart()
        {
            const string Blue = @"<Chart BackColor=""#D3DFF0"" BackGradientStyle=""TopBottom"" BackSecondaryColor=""White"" BorderColor=""26, 59, 105"" BorderlineDashStyle=""Solid"" BorderWidth=""2"" Palette=""BrightPastel"">
                    <ChartAreas>
                           <ChartArea Name=""Default"" _Template_=""All"" BackColor=""64, 165, 191, 228"" BackGradientStyle=""TopBottom"" BackSecondaryColor=""White"" BorderColor=""64, 64, 64, 64"" BorderDashStyle=""Solid"" ShadowColor=""Transparent"" />
                    </ChartAreas>
                    <Legends>
                           <Legend _Template_=""All"" BackColor=""Transparent"" Font=""Trebuchet MS, 8.25pt, style=Bold"" IsTextAutoFit=""False"" />
                    </Legends>
                    <BorderSkin SkinStyle=""Emboss"" />
                    </Chart>";
            var chart = new SimpleChart.Chart(width: 700, height: 300, theme: Blue)
            .AddTitle("График посещений")
            .AddSeries(
                  name: "Моя программа",
                  chartType: "Line",
                  xValue: new[] { "Peter", "Andrew", "Julie", "Mary", "Dave" },
                  yValues: new[] { "2", "6", "4", "5", "3" })
            .AddLegend()
            .Write();


            return null;

        } 
        #endregion

        public ActionResult Foto()
        {
            return View();
        }
        public ActionResult Kardio()
        {
            return View();
        }

        public ActionResult Sila()
        {
            return View();
        }
        public ActionResult Room()
        {
            return View();
        }
        public ActionResult News1()
        {
            return View();
        }
        public ActionResult News2()
        {
            return View();
        }
        public ActionResult Slaid()
        {
            ViewBag.Message = "Slaid";

            return View();
        }
    }
}
