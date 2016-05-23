using DbLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MietTest.TestCache
{
    public class TestGuidModel
    {
        public Guid Guid { get; set; }
        public TestResult Test { get; set; }
    }
}