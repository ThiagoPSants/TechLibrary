using FluentValidation;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Api.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestUserJson>

    {
        public RegisterUserValidator()
        {
            RuleFor(request => request.Nome).NotEmpty().WithMessage("O Nome é Obrigatório.");
            RuleFor(request => request.Email).EmailAddress().WithMessage("O Email  não é Válido.");
            RuleFor(request => request.Password).NotEmpty().WithMessage("O Email  não é Válido.");
            When(request => string.IsNullOrEmpty(request.Password) == false,() =>
            {
                RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(6).WithMessage("A Senha deve conter mais que 6 Caracteres.");
            });
            
        }
    }
}
