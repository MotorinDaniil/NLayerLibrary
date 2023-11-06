using NLayerLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerLibrary.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> Book { get; }
        void Save();
    }
}
