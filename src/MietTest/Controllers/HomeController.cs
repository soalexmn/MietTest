using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbLayer.Contexts;
using DbLayer.Entities;
using DbLayer.Interfaces;
using System.Threading.Tasks;

namespace MietTest.Controllers
{
    public class HomeController : Controller
    {
        private IGenericRepository<Test> _repository;
        public HomeController(IGenericRepository<Test> repository)
        {
            _repository = repository;
        }
        public async Task<ActionResult> Index()
        {
            var tests = await _repository.GetAll().ToArrayAsync();
            ViewBag.Tests = tests;
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