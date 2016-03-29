﻿using DbLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MietTest.TestCache
{
    public interface ITestCache
    {
        Guid StartNewTest(string userName);
        TestResult UpdateTest(Guid guid, string userName, TestResult test);
        TestResult GetTest(Guid guid, string userName);
    }
}
