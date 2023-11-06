using System.ComponentModel.DataAnnotations;
namespace NLayerLibrary.BLL.DTO
{
    public class BookDTO
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime DateTaken { get; set; }
        public DateTime DateToReturn { get; set; }
    }
}
