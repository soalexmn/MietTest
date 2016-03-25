using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbLayer.Contexts;

namespace MietTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            using (var context = new MainContext())
            {
                context.Tests.ToArray();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}