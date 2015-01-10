using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleChart = System.Web.Helpers;

namespace SportClub.Controllers
{
    public class ChartController : Controller
    {
        //
        // GET: /Chart/

        public ActionResult Chart()
        {
            var chart = new SimpleChart.Chart(width: 700, height: 300)
             .AddTitle("График посещений")
             .AddSeries(
                    name: "Моя программа",
                    legend: "Моя программа",
                    chartType: "Line",
                    xValue: new[] { "Peter", "Andrew", "Julie", "Mary", "Dave" },
                    yValues: new[] { "2", "6", "4", "5", "3" })
             .Write();
            
            return null;

        }

    }
}
