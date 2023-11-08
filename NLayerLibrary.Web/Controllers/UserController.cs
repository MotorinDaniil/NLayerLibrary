using NLayerLibrary.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayerLibrary.BLL.DTO;
using NLayerLibrary.WEB;

namespace NLayerLibrary.Web.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserService userService;
        public UserController(IConfiguration configuration, UserService Service)
        {
            _configuration = configuration;
            userService = Service;
        }

        [HttpPost("/registration")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public UserDTO Registration(UserDTO personDTO)
        {
            return userService.Registration(personDTO);
        }

        [AllowAnonymous]
        [HttpPost(nameof(auth))]
        public IActionResult auth( string email,string password)
        {
            string token = userService.GetToken(email, password);
            if (token == null)
            {
                return BadRequest("Please pass the valid Username and Password");
            }
            return Ok(new { Token = token, Message = "Success" });
        }

        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(nameof(getResult))]
        public IActionResult getResult()
        {
            return Ok("API Validated");
        }
    }
}