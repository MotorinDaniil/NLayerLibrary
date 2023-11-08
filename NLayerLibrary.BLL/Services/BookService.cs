using NLayerLibrary.BLL.Interfaces;
using NLayerLibrary.DAL.Repositories;
using NLayerLibrary.DAL.Entities;
using AutoMapper;
using NLayerLibrary.BLL.DTO;

namespace NLayerLibrary.BLL.Services
{
    public class BookService : IBookService
    {
        BookRep rep = new BookRep();

        public async Task<IEnumerable<Book>> GetAll(int page = 1, int pageSize = 3)
        {
            return rep.GetAll(page, pageSize);
        }

        public Book GetByISBN(string ISBN)
        {
            return rep.GetByISBN(ISBN);
        }
        public Book GetById(int id)
        {
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
            return rep.Delete(id);
        }
    }
}
