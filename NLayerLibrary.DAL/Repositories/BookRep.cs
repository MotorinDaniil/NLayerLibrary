using AutoMapper;
using NLayerLibrary.DAL.Entities;
using NLayerLibrary.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayerLibrary.DAL.Interfaces;
using System;

namespace NLayerLibrary.DAL.Repositories
{
    public class BookRep : IRepository<Book>
    {
        public IEnumerable<Book> GetAll()
        {
            using (BookContext db = new BookContext())
            {
                if (db.Book == null)
                {
                    return null;
                }
                return db.Book.ToList();
            }

        }

        public Book Get(int id)
        {
            using (BookContext db = new BookContext())
            {
                if (!BookExists(id))
                {
                    return null;
                }
                return db.Book.Find(id);
            }

        }

        public Book GetByISBN(string ISBN)
        {
            using (BookContext db = new BookContext())
            {
                if (!BookExists(ISBN))
                {
                    return null;
                }
                return db.Book.Where(b => b.ISBN == ISBN).First();
            }
        }

        public Book Create(Book book)
        {
            using (BookContext db = new BookContext())
            {
                db.Book.Add(book);
                db.SaveChanges();
                return book;
            }

        }

        public Book Update(int id, Book newBook)
        {
            using (BookContext db = new BookContext())
            {
                if (!BookExists(id))
                {
                    return null;
                }
                newBook.Id = id;
                db.Entry(newBook).State = EntityState.Modified;
                db.SaveChanges();
                return newBook;
            }

        }

        public Book Delete(int id)
        {
            using (BookContext db = new BookContext())
            {
                Book book = db.Book.Find(id);
                if (book != null)
                {
                    db.Book.Remove(book);
                    db.SaveChanges();
                    return book;
                }
                else return null;
            }

        }
        private bool BookExists(int id)
        {
            using (BookContext context = new BookContext())
            {
                return (context.Book?.Any(b => b.Id == id)).GetValueOrDefault();
            }
    

        }
        private bool BookExists(string ISBN)
        {
            using (BookContext context = new BookContext())
            {
                return (context.Book?.Any(b => b.ISBN == ISBN)).GetValueOrDefault();
            }
        }
    }
}   
