using FluentValidation;
using WeatherMicroservice.Models;

namespace WeatherMicroservice.Validators
{
    public class WeatherRequestValidator : AbstractValidator<WeatherRequest>
    {
        public WeatherRequestValidator()
        {
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(50).WithMessage("City name cannot be longer than 50 characters.");
        }
    }
}
