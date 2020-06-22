using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace DataAccess
{
    public class BookStoreRepo
    {
        public IList<Book> GetAllBooks()
        {
            using (var ctx = new BookStoreContext())
            {
                return ctx.Books
                    .Include(book => book.Writers)
                    .Include(book => book.Category)
                    .ToList();
            }
        }

        public Book GetBookById(int id)
        {
            using (var ctx = new BookStoreContext())
            {
                return ctx.Books
                    .Include(book => book.Writers)
                    .Include(book => book.Category)
                    .First(book => book.Id == id);
            }
        }

        public void SaveBook(Book book)
        {
            using (var ctx = new BookStoreContext())
            {
                var writers = new List<Writer>();
                book.Category = ctx.Categories.First(category => category.Id == book.Category.Id);
                foreach (var bookWriter in book.Writers)
                {
                    writers.Add(ctx.Writers.First(writer => writer.Id == bookWriter.Id));
                }

                book.Writers = writers;
                ctx.Books.Add(book);
                ctx.SaveChanges();
            }
        }

        public void UpdateBook(Book book)
        {
            using (var ctx = new BookStoreContext())
            {
                // ctx.Entry(book).State = EntityState.Modified;
                ctx.Books.AddOrUpdate(book);
                ctx.SaveChanges();
            }
        }

        public void RemoveBookById(int id)
        {
            using (var ctx = new BookStoreContext())
            {
                ctx.Books.Remove(ctx.Books.First(book => book.Id == id));
                ctx.SaveChanges();
            }
        }

        public IList<Category> GetAllCategories()
        {
            using (var ctx = new BookStoreContext())
            {
                return ctx.Categories
                    .Include(category => category.Books)
                    .ToList();
            }
        }

        public Category GetCategoryById(int id)
        {
            using (var ctx = new BookStoreContext())
            {
                return ctx.Categories
                    .Include(category => category.Books)
                    .First(category => category.Id == id);
            }
        }

        public IList<Writer> GetAllWriters()
        {
            using (var ctx = new BookStoreContext())
            {
                return ctx.Writers
                    .Include(category => category.Books)
                    .ToList();
            }
        }

        public Writer GetWriterById(int id)
        {
            using (var ctx = new BookStoreContext())
            {
                return ctx.Writers
                    .Include(writer => writer.Books)
                    .First(writer => writer.Id == id);
            }
        }
    }
}
