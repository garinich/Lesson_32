using System.Collections.Generic;

namespace BusinessLayer.ModelsDTO
{
    public class WriterDTO
    {
        public WriterDTO()
        {
            Books = new List<BookDTO>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookDTO> Books { get; set; }
    }
}
