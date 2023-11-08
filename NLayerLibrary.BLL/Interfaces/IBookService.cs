using NLayerLibrary.BLL.DTO;
using NLayerLibrary.DAL.Entities;

namespace NLayerLibrary.BLL.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll(int page,int pageSize);
        Book GetById(int id);
        Book GetByISBN(string ISBN);
        Book Create(BookDTO bookDTO);
        Book Update(int id,BookDTO book);
        Book Delete(int id);
    }
}
