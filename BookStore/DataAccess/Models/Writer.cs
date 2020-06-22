using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Writer
    {
        public Writer()
        {
            Books = new List<Book>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
