using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Shared.DTOs.Request;

namespace WeatherFinder.Shared.Validators
{
    public class ActivityRequestValidator:AbstractValidator<ActivityRequest>
    {
        public ActivityRequestValidator()
        {
            RuleFor(model => model.Description).MaximumLength(int.MaxValue);
            RuleFor(model => model.Activity).IsInEnum();
        }
    }
}
