using FluentValidation;
using MechaSync.Domain.Requests;

namespace MechaSync.Services.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {

        public LoginValidator()
        {
            RuleSet("LoginValidator", () =>
            {
                RuleFor(x => x.Email)
                    .EmailAddress()
                    .WithMessage("Este email não está válido!");

                RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("Email não pode estar vazio!");

                RuleFor(x => x.Senha)
                    .NotEmpty()
                    .WithMessage("Senha não pode estar vazia!");
            });
        }
    }
}
