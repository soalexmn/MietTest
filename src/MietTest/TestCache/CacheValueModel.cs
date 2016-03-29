using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbLayer.Entities;

namespace MietTest.TestCache
{
    public class CacheValueModel
    {
        public string UserName { get; set; }
        public TestResult Test { get; set; }
    }
}