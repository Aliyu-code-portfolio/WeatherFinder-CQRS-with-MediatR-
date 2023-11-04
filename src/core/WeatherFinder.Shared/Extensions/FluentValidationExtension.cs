using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherFinder.Shared.Extensions
{
    public static class FluentValidationExtension
    {
        public static IRuleBuilder<T, string> FullName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .MaximumLength(50)
                .Must(n => n.Split(" ").Length >= 2)
                .WithMessage("Full name must contain at least two names")
                .Matches("/^[A-Za-z]+$/").WithMessage("Name must only contains alphabets");
        }
    }
}
