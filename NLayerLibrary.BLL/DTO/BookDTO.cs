using System.ComponentModel.DataAnnotations;

namespace NLayerLibrary.BLL.DTO
{
    public class BookDTO
    {
        [Required]

        public string ISBN { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required] 
        public string Genre { get; set; }
        [Required] 
        public string Description { get; set; }
        [Required] 
        public string Author { get; set; }

        [Required] 
        public DateTime DateTaken { get; set; }
        [Required] 
        public DateTime DateToReturn { get; set; }
    }
}
