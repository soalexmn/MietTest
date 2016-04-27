using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DbLayer.Entities;
using DbLayer.Interfaces;
using DbLayer.Repositories;
using MietTest.Controllers;
using MietTest.TestCache;
using MietTest.Tests.TestClasses;

namespace MietTest.Tests
{
    [TestClass]
    public class TestTestController
    {
        private ITestRepository _repository;
        private ITestCache _cache;
        private TestController _controller;
        static string userName = "testuser";

        [TestInitialize]
        public void Init()
        {
            _cache = new TestMemoryCache();
            _repository = new Mock<ITestRepository>(MockBehavior.Loose).Object;
            _controller = new TestController(_repository, _cache);

            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(p => p.HttpContext.User.Identity.Name).Returns(userName);
            controllerContextMock.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);
            _controller.ControllerContext = controllerContextMock.Object;
        }


        [TestMethod]
        public void MainViewIsNotNull()
        {
            var res = _controller.Create();
            Assert.IsNotNull(res);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetTestExpectedException()
        {
            var result = _controller.GetTest(1);
        }

        [TestMethod]
        public void CreateTestAllowResult()
        {
            var res = _controller.CreateTest(new Test());
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void StartAllowRedirect()
        {
            var res = _controller.Start(1);
            Assert.IsInstanceOfType(res, typeof(RedirectResult));
        }

        [TestMethod]
        public void StartAllowUrlPattern()
        {
            var res = _controller.Start(1);
            string url = ((RedirectResult)res).Url;
            Assert.IsTrue( url.Contains("Do?id="));
        }
    }
}
