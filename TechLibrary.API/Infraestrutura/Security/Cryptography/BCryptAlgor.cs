namespace TechLibrary.API.Infraestrutura.Security.Cryptography
{
    public class BCryptAlgor
    {
        public string HashPassword (string password) => BCrypt.Net.BCrypt.HashPassword(password);
    }
}
