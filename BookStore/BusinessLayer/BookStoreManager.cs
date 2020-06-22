using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.ModelsDTO;
using DataAccess;
using DataAccess.Models;

namespace BusinessLayer
{
    public class BookStoreManager
    {
        private readonly BookStoreRepo _bookStoreRepo;
        private readonly Mapper _mapper;

        public BookStoreManager()
        {
            _bookStoreRepo = new BookStoreRepo();

            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<Writer, WriterDTO>();
                cfg.CreateMap<Category, CategoryDTO>();

                cfg.CreateMap<BookDTO, Book>();
                cfg.CreateMap<WriterDTO, Writer>();
                cfg.CreateMap<CategoryDTO, Category>();
            });

            _mapper = new Mapper(conf);
        }

        public IList<BookDTO> GetAllBooks()
        {
            return _mapper.Map<IList<BookDTO>>(_bookStoreRepo.GetAllBooks());
        }

        public BookDTO GetBookById(int id)
        {
            return _mapper.Map<BookDTO>(_bookStoreRepo.GetBookById(id));
        }

        public void AddOrUpdateBook(BookDTO bookDTO)
        {
            bookDTO.Writers = new List<WriterDTO>();

            bookDTO.WriterIds.ForEach(bookWriterId =>
            {
                bookDTO.Writers.Add(_mapper.Map<WriterDTO>(_bookStoreRepo.GetWriterById(bookWriterId)));
            });
            bookDTO.Category = _mapper.Map<CategoryDTO>(_bookStoreRepo.GetCategoryById(bookDTO.CategoryId));

            _bookStoreRepo.SaveBook(_mapper.Map<Book>(bookDTO));
        }

        public void UpdateBook(BookDTO bookDTO)
        {
            bookDTO.Writers = new List<WriterDTO>();

            bookDTO.WriterIds.ForEach(bookWriterId =>
            {
                bookDTO.Writers.Add(_mapper.Map<WriterDTO>(_bookStoreRepo.GetWriterById(bookWriterId)));
            });
            bookDTO.Category = _mapper.Map<CategoryDTO>(_bookStoreRepo.GetCategoryById(bookDTO.CategoryId));

            _bookStoreRepo.UpdateBook(_mapper.Map<Book>(bookDTO));
        }

        public void RemoveBookById(int id)
        {
            _bookStoreRepo.RemoveBookById(id);
        }

        public IList<CategoryDTO> GetAllCategories()
        {
            return _mapper.Map<IList<CategoryDTO>>(_bookStoreRepo.GetAllCategories());
        }

        public CategoryDTO GetCategoryById(int id)
        {
            return _mapper.Map<CategoryDTO>(_bookStoreRepo.GetCategoryById(id));
        }

        public IList<WriterDTO> GetAllWriters()
        {
            return _mapper.Map<IList<WriterDTO>>(_bookStoreRepo.GetAllWriters());
        }

        public WriterDTO GetWriterById(int id)
        {
            return _mapper.Map<WriterDTO>(_bookStoreRepo.GetWriterById(id));
        }
    }
}
