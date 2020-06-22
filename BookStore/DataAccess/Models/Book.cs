using System.Collections.Generic;

namespace DataAccess.Models
{

    public class Book
    {
        public Book()
        {
            Writers = new List<Writer>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }

        public ICollection<Writer> Writers { get; set; }
    }
}
