﻿using TechLibrary.Api.Domain.Entities;
using TechLibrary.Api.Infraestrutura;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.UseCases.Users.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {

            Validate(request);

            var entity = new User
            {Email= request.Email,
            Nome = request.Nome,
            Password=request.Password,
            };
            var dbContext = new TechLibraryDbContext();
            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            return new ResponseRegisteredUserJson
            {
                Nome=entity.Nome,
            };
        }
        private void Validate(RequestUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error=> error.ErrorMessage).ToList();

                throw new ErrorOnValidatioException(errorMessages);
            }
        }
    }
    

}
