using NLayerLibrary.DAL.Entities;
using NLayerLibrary.DAL.EF;
using Microsoft.EntityFrameworkCore;
using NLayerLibrary.DAL.Interfaces;
namespace NLayerLibrary.DAL.Repositories
{
    public class BookRep : IRepository<Book>
    {
        LibraryContext context = new LibraryContext();
        public IEnumerable<Book> GetAll(int page, int pageSize)
        {

            if (context.Book == null)
            {
                return null;
            }
            return context.Book.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public Book Get(int id)
        {
            if (!BookExists(id))
            {
                return null;
            }
            return context.Book.Find(id);
        }

        public Book GetByISBN(string ISBN)
        {
            if (!BookExists(ISBN))
            {
                return null;
            }
            return context.Book.Where(b => b.ISBN == ISBN).First();
        }

        public Book Create(Book book)
        {
                context.Book.Add(book);
                context.SaveChanges();
            
            return book;
        }

        public Book Update(int id, Book newBook)
        {
            if (!BookExists(id))
            {
                return null;
            }
            newBook.Id = id;
            context.Entry(newBook).State = EntityState.Modified;
            context.SaveChanges();
            return newBook;
        }

        public Book Delete(int id)
        {
            Book book = context.Book.Find(id);
            if (book != null)
            {
                context.Book.Remove(book);
                context.SaveChanges();
                return book;
            }
            else return null;
        }
        private bool BookExists(int id)
        {
            return (context.Book?.Any(b => b.Id == id)).GetValueOrDefault();
        }
        private bool BookExists(string ISBN)
        {
            return (context.Book?.Any(b => b.ISBN == ISBN)).GetValueOrDefault();
        }

    }
}
