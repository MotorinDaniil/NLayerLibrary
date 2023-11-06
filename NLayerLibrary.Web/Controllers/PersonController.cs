using Microsoft.AspNetCore.Mvc;
using NLayerLibrary.BLL.DTO;
using NLayerLibrary.BLL.Services;

namespace NLayerLibrary.Web.Controllers
{
    [Route("/api/users")]
    [ApiController]
    public class PersonController : Controller
    {
        PersonService personService;

        public PersonController(PersonService service)
        {
            personService = service;
        }
        [HttpPost]
        public PersonDTO Register(PersonDTO personDTO)
        {
            return personService.Register(personDTO);
        }

    }
}
