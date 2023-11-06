using NLayerLibrary.DAL.EF;
using NLayerLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerLibrary.DAL.Repositories
{
    public class PersonRep
    {
        public bool Login(string email, string password)
        {
            using(UserContext context = new UserContext())
            {
                if (!UserExists(email))
                {
                    return false;
                }
                if (context.Person.Any(u => u.Email == email && u.Password == password)) 
                {
                    return true;
                }
                return false;
            }
        }

        public Person GetByEmail(string email)
        {
            using(UserContext userContext = new UserContext())
            {
                return userContext.Person.Where(p => p.Email == email).FirstOrDefault();
            }
        }

        public Person Register(Person person) 
        {
            using(UserContext context = new UserContext())
            {
                context.Person.Add(person);
                context.SaveChanges();
                return person;
            }
        }
        private bool UserExists(string email)
        {
            using (UserContext context = new UserContext())
            {
                return (context.Person?.Any(b => b.Email == email)).GetValueOrDefault();
            }
        }
    }
}
