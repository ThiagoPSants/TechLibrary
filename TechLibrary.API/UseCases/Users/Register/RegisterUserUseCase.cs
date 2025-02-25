using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using TechLibrary.Api.Domain.Entities;
using TechLibrary.Api.Infraestrutura;
using TechLibrary.API.Infraestrutura.Security.Cryptography;
using TechLibrary.API.UseCases.Users.Register;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.UseCases.Users.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {
            var dbContext = new TechLibraryDbContext();
            var cryptography = new BCryptAlgor();

            Validate(request, dbContext);

            var entity = new User
            {    Email= request.Email,

                 Nome = request.Nome,

                 Password=cryptography.HashPassword(request.Password),
            };
           
            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            return new ResponseRegisteredUserJson
            {
                Nome=entity.Nome,
            };
        }
        private void Validate(RequestUserJson request,TechLibraryDbContext dbContext)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            var existUserWithEmail = dbContext.Users.Any(user => user.Email.Equals(request.Email)); ;

            if (existUserWithEmail)
                result.Errors.Add(new ValidationFailure("Email","Email Já Cadastrado na  plataforma"));

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error=> error.ErrorMessage).ToList();

                throw new ErrorOnValidatioException(errorMessages);
            }
        }
    }
    

}
