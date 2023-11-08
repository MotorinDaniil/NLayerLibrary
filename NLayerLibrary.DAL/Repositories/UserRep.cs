using NLayerLibrary.DAL.EF;
using NLayerLibrary.DAL.Entities;

namespace NLayerLibrary.DAL.Repositories
{
    public class UserRep
    {
        LibraryContext context = new LibraryContext();

        public bool Login(string email, string password)
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

        public User GetByEmail(string email)
        {
            return context.Person.Where(p => p.Email == email).FirstOrDefault();
        }

        public User Register(User person)
        {
            context.Person.Add(person);
            context.SaveChanges();
            return person;
        }
        private bool UserExists(string email)
        {
            return (context.Person?.Any(b => b.Email == email)).GetValueOrDefault();
        }
    }
}
