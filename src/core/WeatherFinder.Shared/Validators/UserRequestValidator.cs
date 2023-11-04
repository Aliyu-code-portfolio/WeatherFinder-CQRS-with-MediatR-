using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Shared.DTOs.Request;

namespace WeatherFinder.Shared.Validators
{
    public class UserRequestValidator:AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(model => model.FullName).MaximumLength(50).WithMessage("Full name must be max 50 characters").Matches("/^[A-Za-z]+$/").WithMessage("Name must only contains alphabets");
            RuleFor(model => model.Email).EmailAddress().WithMessage("Invalid email address").MaximumLength(100).WithMessage("Email must be max 100 characters");
        }
    }
}
