using DbLayer.Entities;
using DbLayer.Interfaces;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Repositories
{
    public class EfTestRepository : EfGenericRepository<Test>, ITestRepository
    {
        public override Test Add(Test entity)
        {
            return Context.Tests.Add(entity);
        }

        public Test Add(Test test, string userName)
        {
            var user = Context.Users.Include(u => u.Tests).First(u => u.UserName == userName);
            user.Tests.Add(test);
            return test;
        }

        public void AddTestResult(TestResult testResult,bool save = true)
        {
            int testId = (int)testResult.TestId;
            var test = Context.Tests
                .Include(p => p.TestResults)
                .First(p => p.Id == testId);

            test.TestResults.Add(testResult);
        }

        public Test GetFullTest(int testId)
        {
            return Context.Tests
                .Include("Questions")
                .Include("Questions.AnswerVariants")
                .First(t => t.Id == testId);
        }


        public TestResult GetFullTestResult(int id)
        {
            var res = Context.TestResults
                .Include(p => p.QuestionResults)
                .Include(p => p.QuestionResults.Select(r => r.Question))
                .Include(p => p.Test)
                .First(p => p.Id == id);
            res.QuestionResults = res.QuestionResults.OrderBy(r => r.QuestionId).ToList();
            return res;
        }
    }
}
