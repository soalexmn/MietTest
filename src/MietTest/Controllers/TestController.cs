using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MietTest.Controllers
{
    public class TestController : Controller
    {
        public TestController()
        {

        }
        // GET: Test
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddTest()
        {
            return null;
        }
    }
}