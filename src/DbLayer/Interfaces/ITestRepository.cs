using DbLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Interfaces
{
    public interface ITestRepository : IGenericRepository<Test>
    {
        Test Add(Test test, string userName);

        Test GetFullTest(int testId);

        void AddTestResult(TestResult testResult);

        TestResult GetFullTestResult(int id);
    }
}
