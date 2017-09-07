using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBIB.Models
{
    public class ResearchInfo
    {
        // Author(s), Title, Year of publication, Type of Research Output, and additional information depending on the specific type of research output

        public int ID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string AdditionalInfo { get; set; }
        public string Node { get; set;}
    
}
}
