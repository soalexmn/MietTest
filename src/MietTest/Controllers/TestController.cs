using DbLayer.Entities;
using DbLayer.Interfaces;
using MietTest.Models;
using MietTest.TestCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MietTest.Controllers
{
    public class TestController : Controller
    {
        private ITestRepository _repository;
        private ITestCache _cache;

        public TestController(ITestRepository repository, ITestCache cache)
        {
            _repository = repository;
            _cache = cache;
        }
        // GET: Test/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> CreateTest(Test test)
        {
            _repository.Add(test,this.User.Identity.Name);
            await _repository.SaveChangesAsync();
            return Json(test);
        }

        [OutputCache(Duration=0,NoStore=true,VaryByParam="none")]
        [Authorize]
        public ActionResult Start(int id)
        {
            Guid guid = _cache.StartNewTest(this.User.Identity.Name);
            return Redirect(String.Concat("~/Test/Do?id=",id,"&s=",guid));
        }

        [Authorize]
        public ActionResult Do(int id, Guid s)
        {
            ViewBag.Id = id;
            ViewBag.Guid = s;
            return View();
        }

        [Authorize]
        [OutputCache(Duration = 0, NoStore = true, VaryByParam = "none")]
        public ActionResult GetTest(int id)
        {
           Test test = _repository.GetFullTest(id);
           foreach (var question in test.Questions)
           {
               question.Result = string.Empty;
           }
           return Json(test, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [OutputCache(Duration = 0, NoStore = true, VaryByParam = "none")]
        public ActionResult GetTestResult(Guid s)
        {
            try
            {
                TestResult test = _cache.GetTest(s, this.User.Identity.Name);
                return Json(test,JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                Response.StatusCode = 500;
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize]
        public ActionResult UpdateTestResult(TestUpdateViewModel model)
        {
            try
            {
                TestResult test = _cache.UpdateTest(model.Guid, this.User.Identity.Name, model.Test);
                return Json(test);
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(e.Message);
            }
        }
    }
}