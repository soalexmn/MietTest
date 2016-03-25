using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Entities
{
    public class TestResult
    {
        public TestResult()
        {
            QuestionResults = new List<QuestionResult>();
        }
        [Key]
        public int Id { get; set; }
        
        public string userId { get; set; }
        public User User { get; set; }

        public int? TestId { get; set; }
        public Test Test { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public ICollection<QuestionResult> QuestionResults { get; set; }


    }
}
