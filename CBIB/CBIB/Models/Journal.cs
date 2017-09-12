using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBIB.Models
{
    public class Journal
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }

        public long AuthorID { get; set; }
    }
}
