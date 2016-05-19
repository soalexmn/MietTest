using DbLayer.Entities;
using DbLayer.Interfaces;
using MietTest.Models;
using MietTest.TestCache;
using MietTest.Verification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

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
        public ActionResult Result()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> CreateTest(Test test)
        {
            _repository.Add(test, this.User.Identity.Name);
            await _repository.SaveChangesAsync();
            return Json(test);
        }

        [OutputCache(Duration = 0, NoStore = true, VaryByParam = "none")]
        [Authorize]
        public ActionResult Start(int id)
        {
            Guid guid = _cache.StartNewTest(this.User.Identity.Name, id);
            return Redirect(String.Concat("~/Test/Do?id=", id, "&s=", guid));
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
                return Json(test, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
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
                return new ContentResult
                {
                    Content = JsonConvert.SerializeObject(test, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }),
                    ContentType = "application/json",
                    ContentEncoding = System.Text.Encoding.UTF8
                };
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(e.Message);
            }
        }

        public ActionResult DoneTest(TestUpdateViewModel model)
        {

            var test = _repository.GetFullTest((int)model.Test.TestId);
            var testResultBefore = _cache.GetTest(model.Guid, this.User.Identity.Name);

            var testResult = model.Test;
            testResult.End = DateTime.Now;
            testResult.userId = this.User.Identity.GetUserId();
            VerifyHelper verificator = new VerifyHelper();
            testResult = verificator.SetIsCorrect(test, testResult);

            _repository.AddTestResult(testResult);
            _repository.SaveChanges();
            return Json(testResult);
        }

        [Authorize]
        [NoCache]
        public ActionResult GetResult(int id)
        {
            var res = _repository.GetFullTestResult(id);
            return Json(res);
        }
    }
}