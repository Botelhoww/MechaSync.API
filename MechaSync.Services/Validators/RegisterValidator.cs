using FluentValidation;
using MechaSync.Domain.Requests;

namespace MechaSync.Services.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {

        public RegisterValidator()
        {
            RuleSet("RegisterValidator", () =>
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

                RuleFor(x => x.Funcao)
                    .NotEmpty()
                    .WithMessage("Função não pode estar vazio!");
            });
        }
    }
}
