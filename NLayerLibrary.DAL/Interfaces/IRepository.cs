using NLayerLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerLibrary.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T GetByISBN(string ISBN);
        T Create(T item);
        T Update(int id,Book item);
        T Delete(int id);
    }
}
