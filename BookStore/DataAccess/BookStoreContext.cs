using System.Data.Entity;
using DataAccess.Models;

namespace DataAccess
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new CustomInitializer());
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
