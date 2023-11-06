using NLayerLibrary.BLL.DTO;
using NLayerLibrary.DAL.Entities;

namespace NLayerLibrary.BLL.DTO
{
    public class IndexViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
