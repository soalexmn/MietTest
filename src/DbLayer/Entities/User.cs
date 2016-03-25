using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Tests = new List<Test>();
            TestResults = new List<TestResult>();
        }

        public ICollection<Test> Tests { get; set; }
        public ICollection<TestResult> TestResults { get; set; }
    }
}
