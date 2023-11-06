using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLayerLibrary.DAL.Entities

{
    public class Book
    {
        public int Id { get; set; }
         public string ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime DateTaken { get; set; }
        public DateTime DateToReturn { get; set; }

       
    }
}
