using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Entities
{
    public class Topic
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }

    }
}
