using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerLibrary.BLL.DTO
{
    public class PersonDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }

        [DefaultValue("user")]
        public string Role { get; set; }
    }
}
