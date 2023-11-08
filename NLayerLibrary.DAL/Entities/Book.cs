using System.ComponentModel.DataAnnotations;
namespace NLayerLibrary.DAL.Entities

{
    public class Book
    {
        [Required] public int Id { get; set; }
        [Required] public string ISBN { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Genre { get; set; }
        [Required] public string Description { get; set; }
        [Required] public string Author { get; set; }
        [Required] public DateTime DateTaken { get; set; }
        [Required] public DateTime DateToReturn { get; set; }
    }
}
