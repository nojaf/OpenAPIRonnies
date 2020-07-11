using FluentValidation;

namespace OpenAPIRonnies.Validations
{
    public class CreateOrUpdateRonnyValidator : AbstractValidator<CreateOrUpdateRonny>
    {
        public CreateOrUpdateRonnyValidator()
        {
            RuleFor(r => r.Name).NotEmpty().MaximumLength(100);
            RuleFor(r => r.Price).NotEmpty().GreaterThan(0);
        }
    }
}