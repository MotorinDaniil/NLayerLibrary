using NLayerLibrary.BLL.Interfaces;
using NLayerLibrary.DAL.Repositories;
using NLayerLibrary.DAL.Entities;
using AutoMapper;
using NLayerLibrary.BLL.Infrastructure;
using NLayerLibrary.BLL.DTO;
using NLayerLibrary.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace NLayerLibrary.BLL.Services
{
    public class BookService:IBookService
    {
        BookRep rep = new BookRep();

        public async Task<IndexViewModel> GetAll(int page=1,int pageSize=3)
        {
            using(BookContext db = new BookContext())
            {
                IQueryable<Book> source = db.Book;
                var count = await source.CountAsync();
                var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
                IndexViewModel viewModel = new IndexViewModel
                {
                    PageViewModel = pageViewModel,
                    Books = items
                };
                return viewModel;
            }
        }

        public Book GetByISBN(string ISBN)
        {
            if (ISBN == null)
            {
                throw new ValidationException("Book has not found", "");
            }
            return rep.GetByISBN(ISBN);
        }
        public Book GetById(int id)
        {
            if (id == null)
            {
                throw new ValidationException("Book has not found", "");
            }
            return rep.Get(id);

        }
        public Book Create(BookDTO bookDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>()).CreateMapper();
            Book book = mapper.Map<Book>(bookDTO);
            return rep.Create(book);
            
        }
        public Book Update(int id, BookDTO bookDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>()).CreateMapper();
            Book book = mapper.Map<Book>(bookDTO);
            return rep.Update(id, book);
        }
       
        public Book Delete(int id)
        {
            if (id == null)
            {
                throw new ValidationException("Book has not found", "");
            }
            return rep.Delete(id);
            
        }
    }
}
