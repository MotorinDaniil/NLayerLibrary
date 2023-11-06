using System.ComponentModel;

namespace NLayerLibrary.Web.Models
{
    public class Person
    {
        int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [DefaultValue("user")]
        public string Role { get; set; }
    }
}
