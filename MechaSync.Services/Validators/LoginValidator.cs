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
                    .WithMessage("Email not valid!");

                RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("Email can`t be empty!");

                RuleFor(x => x.Password)
                    .NotEmpty()
                    .WithMessage("Password can`t be empty!");
            });
        }
    }
}