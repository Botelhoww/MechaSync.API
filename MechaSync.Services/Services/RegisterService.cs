using FluentValidation;
using MechaSync.Domain.Requests;

namespace MechaSync.Services.Services
{
    public class RegisterService
    {
        public static void IsValid(RegisterRequest registerRequest, IValidator<RegisterRequest> validator)
        {
            validator.Validate(registerRequest, options =>
            {
                options.ThrowOnFailures();
                options.IncludeRuleSets("RegisterValidator");
            });
        }
    }
}
