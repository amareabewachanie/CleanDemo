using FluentValidation;

namespace CleanDemo.Application.Features.Births.Commands.Create
{
    public class CreateBirthValidator :AbstractValidator<CreateBirthCommand>
    {
        public CreateBirthValidator()
        {
            RuleFor(a=>a.BirthDate)
                .NotEmpty().WithMessage("Birth date should not be empty");
            RuleFor(a => a.FirstName)
                .NotEmpty().WithMessage("Date of birth should not be empty");
        }
    }
}
