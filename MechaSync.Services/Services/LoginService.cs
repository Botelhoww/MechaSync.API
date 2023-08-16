using FluentValidation;
using MechaSync.Domain.Requests;

namespace MechaSync.Services.Services
{
    public class LoginService
    {
        public static void IsValid(LoginRequest loginRequest, IValidator<LoginRequest> validator)
        {
            validator.Validate(loginRequest, options =>
            {
                options.ThrowOnFailures();
                options.IncludeRuleSets("LoginValidator");
            });
        }
    }
}