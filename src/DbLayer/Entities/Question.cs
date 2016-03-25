﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Entities
{
    public class Question
    {
        public Question()
        {
            AnswerVariants = new List<AnswerVariant>();
        }
        [Key]
        public int Id { get; set; }

        public string Body { get; set; }

        public ICollection<AnswerVariant> AnswerVariants { get; set; }
    }
}
