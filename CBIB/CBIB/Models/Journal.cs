namespace CBIB.Models
{
    public class Journal
    {
        public int ID { get; set; }
        public string Title  { get; set; }
        public string Year { get; set; }

        public long AuthorID { get; set; }
    }
}
