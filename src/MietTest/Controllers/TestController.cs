using DbLayer.Entities;
using DbLayer.Interfaces;
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
        private IGenericRepository<Test> _repository;
        public TestController(IGenericRepository<Test> repository)
        {
            _repository = repository;
        }
        // GET: Test
        public ActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> CreateTest(Test test)
        {
            _repository.Add(test);
            await _repository.SaveChangesAsync();
            return Json(test);
        }
    }
}