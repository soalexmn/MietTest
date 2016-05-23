using DbLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MietTest.TestCache
{
    public interface ITestCache
    {
        Guid StartNewTest(string userName, int id);
        TestResult UpdateTest(Guid guid, string userName, TestResult test);
        TestResult GetTest(Guid guid, string userName);

        TestGuidModel[] GetTests(string userName);

        void Remove(Guid guid);
    }
}
