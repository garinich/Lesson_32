using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Models;

namespace DataAccess
{
    public class CustomInitializer : DropCreateDatabaseAlways<BookStoreContext> // CreateDatabaseIfNotExists<ShopContext>
    {
        protected override void Seed(BookStoreContext context)
        {
            var categories = new List<Category>()
            {
                new Category{ Name = "Fantastic" },
                new Category{ Name = "Scientific" },
                new Category{ Name = "Fiction" }
            };

            var writers = new List<Writer>()
            {
                new Writer{ Name = "John Tolkien" },
                new Writer{ Name = "James Durbin" },
                new Writer{ Name = "Siem Jan Koopman" },
                new Writer{ Name = "Lev Tolstoy" },
                new Writer{ Name = "Alan Dean Foster" }
            };

            var book1 = new Book {Name = "Lord of the Rings"};
            book1.Category = categories.First(category => category.Name == "Fantastic");
            book1.Writers.Add(writers.Find(writer => writer.Name == "John Tolkien"));

            var book2 = new Book {Name = "Time Series Analysis by State Space Methods"};
            book2.Category = categories.First(category => category.Name == "Scientific");
            book2.Writers.Add(writers.Find(writer => writer.Name == "James Durbin"));
            book2.Writers.Add(writers.Find(writer => writer.Name == "Siem Jan Koopman"));

            var book3 = new Book {Name = "War and Peace"};
            book3.Category = categories.First(category => category.Name == "Fiction");
            book3.Writers.Add(writers.Find(writer => writer.Name == "Lev Tolstoy"));

            var book4 = new Book {Name = "Star Wars: The Force Awakens"};
            book4.Category = categories.First(category => category.Name == "Fantastic");
            book4.Writers.Add(writers.Find(writer => writer.Name == "Alan Dean Foster"));

            context.Books.AddRange(new Book[] {book1, book2, book3, book4});
            context.Categories.AddRange(categories);
            context.Writers.AddRange(writers);

            context.SaveChanges();
        }
    }
}
