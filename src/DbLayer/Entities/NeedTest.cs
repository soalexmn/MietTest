using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Entities
{
    public class NeedTest
    {
        [Key]
        public int Id { get; set; }
        public string Desciption { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
