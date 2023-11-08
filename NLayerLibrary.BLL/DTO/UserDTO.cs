using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace NLayerLibrary.BLL.DTO
{
    public class UserDTO
    {
        [Required] 
        public string Email { get; set; }
        [Required] 
        public string Password { get; set; }

        [Required]
        [DefaultValue("user")]
        public string Role { get; set; }
    }
}
