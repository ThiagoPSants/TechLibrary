using TechLibrary.API.Infraestrutura.DataAccess;
using TechLibrary.API.Infraestrutura.Security.Cryptography;
using TechLibrary.API.Infraestrutura.Security.Tokens.Access;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.API.UseCases.Login.DoLogin;

public class DoLoginUseCase
{
    public ResponseRegisteredUserJson Execute(RequestLoginJson request)
    {
        var dbContext = new TechLibraryDbContext();

        var user = dbContext.Users.FirstOrDefault(user => user.Email.Equals(request.Email));

        if (user is null)
        {
            throw new InvalidLoginException();
        }

        var cryptography = new BCryptAlgor();
        var PasswordIsValid = cryptography.Verify(request.Password, user);

        if (PasswordIsValid == false)

            throw new InvalidLoginException();
        {
            
        }
        var tokenGenerator = new JwtTokenGeneretor();

        return new ResponseRegisteredUserJson
        {
            Nome = user.Nome,
            AccessToken = tokenGenerator.Generate(user)

        };
    }
}
