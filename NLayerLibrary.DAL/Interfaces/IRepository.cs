using NLayerLibrary.DAL.Entities;

namespace NLayerLibrary.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(int page, int pagesize);
        T Get(int id);
        T GetByISBN(string ISBN);
        T Create(T item);
        T Update(int id,Book item);
        T Delete(int id);
    }
}
