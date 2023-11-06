using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NLayerLibrary.Web
{
    public class AuthOptions
    {
        public const string ISSUER = "SecretKey10125779374235322"; // издатель токена
        public const string AUDIENCE = "https://localhost:44341"; // потребитель токена
        public const string KEY = "http://localhost:4200";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
