using System.Collections.Generic;

namespace BusinessLayer.ModelsDTO
{

    public class BookDTO
    {
        public BookDTO()
        {
            Writers = new List<WriterDTO>();
            WriterIds = new List<int>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public List<int> WriterIds { get; set; }

        public CategoryDTO Category { get; set; }

        public virtual ICollection<WriterDTO> Writers { get; set; }
    }
}
