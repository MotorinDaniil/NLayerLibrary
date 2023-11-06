using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerLibrary.DAL.Repositories;
using NLayerLibrary.DAL.Entities;
using NLayerLibrary.BLL.DTO;
using AutoMapper;

namespace NLayerLibrary.BLL.Services
{
    public class PersonService
    {
        PersonRep rep = new PersonRep();

        public bool Login(string email, string password)
        {
            return rep.Login(email,password);
        }
        public PersonDTO Register(PersonDTO personDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonDTO, Person>()).CreateMapper();
            var mapper1 = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonDTO>()).CreateMapper();
            return mapper1.Map<PersonDTO>(rep.Register(mapper.Map<Person>(personDTO)));
        }

        public Person GetByEmail(string email)
        {
            return rep.GetByEmail(email);
        }
    }
}
