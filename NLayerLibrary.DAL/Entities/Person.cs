using System.ComponentModel;

namespace NLayerLibrary.DAL.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [DefaultValue("user")]
        public string Role { get; set; }
    }
}
