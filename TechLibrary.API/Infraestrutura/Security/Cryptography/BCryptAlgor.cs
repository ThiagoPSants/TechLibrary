using TechLibrary.Api.Domain.Entities;

namespace TechLibrary.API.Infraestrutura.Security.Cryptography
{
    public class BCryptAlgor
    {
        public string HashPassword (string password) => BCrypt.Net.BCrypt.HashPassword(password);
        public bool Verify(string password, User user) => BCrypt.Net.BCrypt.Verify(password,user.Password);
    }
}
