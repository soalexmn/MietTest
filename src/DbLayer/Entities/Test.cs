using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Entities
{
    public class Test
    {
        public Test()
        {
            Questions = new List<Question>();
            TestResults = new List<TestResult>();
        }
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<TestResult> TestResults { get; set; }
    }
}
