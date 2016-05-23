using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Entities
{
    public enum QuestionType : int
    {
        One = 0,
        Multi = 1
    }
    public class Question
    {
        public Question()
        {
            AnswerVariants = new List<AnswerVariant>();
            QuestionResults = new List<QuestionResult>();
        }
        [Key]
        public int Id { get; set; }

        public string Body { get; set; }

        public QuestionType QuestionType { get; set; }

        public ICollection<AnswerVariant> AnswerVariants { get; set; }

        public ICollection<QuestionResult> QuestionResults { get; set; }

        public string Result { get; set; }
    }
}
