using NLayerLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace NLayerLibrary.DAL.EF
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {
            Database.EnsureCreated();
        }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<User> Person { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }


    }
}
