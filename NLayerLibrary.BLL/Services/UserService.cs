using NLayerLibrary.DAL.Repositories;
using NLayerLibrary.DAL.Entities;
using NLayerLibrary.BLL.DTO;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace NLayerLibrary.BLL.Services
{
    public class UserService
    {
        private readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        UserRep rep = new UserRep();

        public UserDTO Registration(UserDTO personDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
            var mapper1 = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper1.Map<UserDTO>(rep.Register(mapper.Map<User>(personDTO)));
        }

        public User GetByEmail(string email)
        {
            return rep.GetByEmail(email);
        }

        public string GetToken(string email, string password)
        {
            bool isValid = rep.Login(email, password);
            if (isValid)
            {
                return GenerateJwtToken(email);
            }
            return null;
        }
        private string GenerateJwtToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("email", email) }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
