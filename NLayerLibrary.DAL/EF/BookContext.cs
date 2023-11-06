using NLayerLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace NLayerLibrary.DAL.EF
{
    public class BookContext : DbContext
    {
        public BookContext()
        {
           
        }
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Book { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }


    }
}
