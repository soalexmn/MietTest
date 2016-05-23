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
using MietTest.TestCache;
using Microsoft.AspNet.Identity;

namespace MietTest.Controllers
{
    public class HomeController : Controller
    {
        private IGenericRepository<Test> _repository;
        private ITestCache _cache;
        public HomeController(IGenericRepository<Test> repository, ITestCache cache)
        {
            _repository = repository;
            _cache = cache;
        }
        public async Task<ActionResult> Index()
        {
            var tests = await _repository.GetAll().ToArrayAsync();
            ViewBag.Tests = tests;
            var runTests = _cache.GetTests(this.User.Identity.Name);
            foreach (var runTest in runTests)
            {
               runTest.Test.Test = _repository.GetAll().First(t => t.Id == runTest.Test.TestId);
            }
            ViewBag.RunTests = runTests;
            return View();
        }

        public async Task<ActionResult> Results()
        {
            var userId = this.User.Identity.GetUserId();
            ViewBag.Tests = await _repository.GetAll<TestResult>()
                .Include(tr => tr.Test)
                .Where(tr => tr.userId == userId)
                .ToArrayAsync();
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