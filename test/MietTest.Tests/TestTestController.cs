using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbLayer.Interfaces;
using MietTest.TestCache;
using DbLayer.Repositories;
using MietTest.Tests.TestClasses;
using MietTest.Controllers;

namespace MietTest.Tests
{
    [TestClass]
    public class TestTestController
    {
        private ITestRepository _repository;
        private ITestCache _cache;
        private TestController _controller;

        [TestInitialize]
        public void Init()
        {
            _cache = new TestMemoryCache();
            _repository = new EfTestRepository();
            _repository.SetContext(new MainContextTestable());
            _controller = new TestController(_repository, _cache);
        }

        void Reload()
        {
            _cache = new TestMemoryCache();
            _repository = new EfTestRepository();
            _repository.SetContext(new MainContextTestable());
            _controller = new TestController(_repository, _cache);
        }

        [TestMethod]
        public void AllowAnyTest()
        {
            var tests = _repository.GetAll();

            Assert.IsTrue(tests.Any());
        }

        [TestMethod]
        public void AllowAnyJsonTest()
        {
            var testId = _repository.GetAll().First().Id;

            var result = _controller.GetTest(testId);


            Assert.IsNotNull(result);
        }
    }
}
