using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DbLayer.Entities
{
    public class QuestionResult
    {
        [Key]
        public int Id { get; set; }

        public int? QuestionId { get; set; }
        public Question Question { get; set; }

        public bool IsCorrect { get; set; }
        public string Result { get; set; }
    }
}
