using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbLayer.Entities;

namespace MietTest.Models
{
    public class TestUpdateViewModel
    {
        public Guid Guid { get; set; }
        public TestResult Test { get; set; }
    }
}