using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NLayerLibrary.DAL.Entities
{
    public class User
    {
        [Required] public int Id { get; set; }
        [Required]  public string Email { get; set; }
        [Required] public string Password { get; set; }

        [DefaultValue("user")]
        [Required] public string Role { get; set; }
    }
}
