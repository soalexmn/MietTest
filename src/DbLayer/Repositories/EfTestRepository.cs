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
    public class EfTestRepository : EfGenericRepository<Test>,ITestRepository
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


        public Test GetFullTest(int testId)
        {
            return Context.Tests
                .Include("Questions")
                .Include("Questions.AnswerVariants")
                .First(t => t.Id == testId);
        }
    }
}
