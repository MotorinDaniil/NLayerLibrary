using NLayerLibrary.BLL.DTO;
using NLayerLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerLibrary.BLL.Interfaces
{
    public interface IBookService
    {
        Task<IndexViewModel> GetAll(int page,int pageSize);
        Book GetById(int id);
        Book GetByISBN(string ISBN);
        Book Create(BookDTO bookDTO);
        Book Update(int id,BookDTO book);
        Book Delete(int id);
    }
}
