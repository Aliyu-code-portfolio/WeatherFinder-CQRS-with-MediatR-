using FluentValidation;
using WeatherFinder.Shared.DTOs.Request;
using WeatherFinder.Shared.Extensions;

namespace WeatherFinder.Shared.Validators
{
    public class UserRequestValidator:AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(model => model.FullName).FullName();
            RuleFor(model => model.Email).EmailAddress().MaximumLength(100).WithMessage("Email must be max 100 characters");
        }
    }
}
