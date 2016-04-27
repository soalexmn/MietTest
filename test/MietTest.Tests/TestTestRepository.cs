using DbLayer.Contexts;
using DbLayer.Entities;
using DbLayer.Interfaces;
using DbLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MietTest.Tests
{
    /// <summary>
    /// TO DO: тесты не работают, добавить моки для ф-ий Set и Entry
    /// </summary>
    [TestClass]
    public class TestTestRepository
    {
        ITestRepository _repository;
        static string userName = "testuser";

        [TestInitialize]
        public void Init()
        {
            _repository = new EfTestRepository();
            _repository.SetContext(CreateContextMock());

        }

        MainContext CreateContextMock()
        {
            var contextMock = new Mock<MainContext>();
            contextMock.Setup(p => p.Tests).Returns(GetDbSetMock<Test>(new List<Test>().AsQueryable()).Object);
            contextMock.Setup(p => p.TestResults).Returns(GetDbSetMock<TestResult>(new List<TestResult>().AsQueryable()).Object);
            contextMock.Setup(p => p.Questions).Returns(GetDbSetMock<Question>(new List<Question>().AsQueryable()).Object);
            contextMock.Setup(p => p.AnswerVariants).Returns(GetDbSetMock<AnswerVariant>(new List<AnswerVariant>().AsQueryable()).Object);
            contextMock.Setup(p => p.QuestionResults).Returns(GetDbSetMock<QuestionResult>(new List<QuestionResult>().AsQueryable()).Object);
            contextMock.Setup(p => p.Users).Returns(GetDbSetMock<User>(new List<User>().AsQueryable()).Object);
            return contextMock.Object;
        }

        Mock<DbSet<T>> GetDbSetMock<T>(IQueryable<T> data) where T : class
        {
            var mock = new Mock<DbSet<T>>();
            mock.As<IQueryable<T>>().Setup(d => d.Provider).Returns(data.Provider);
            mock.As<IQueryable<T>>().Setup(d => d.Expression).Returns(data.Expression);
            mock.As<IQueryable<T>>().Setup(d => d.ElementType).Returns(data.ElementType);
            mock.As<IQueryable<T>>().Setup(d => d.GetEnumerator()).Returns(data.GetEnumerator());
            return mock;
        }

        //[TestMethod]
        public void GetAllIsNotNull()
        {
           var res =  _repository.GetAll().ToArray();
           Assert.IsNotNull(res);
        }

        //[TestMethod]
        public void AddResultTest()
        {
            _repository.Add(new Test { Description = "Test" }, userName);
        }


    }
}
