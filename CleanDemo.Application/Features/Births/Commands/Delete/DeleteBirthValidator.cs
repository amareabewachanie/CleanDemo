using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanDemo.Application.Features.Births.Commands.Delete
{
    public class DeleteBirthValidator:AbstractValidator<DeleteBirthCommand>
    {
        public DeleteBirthValidator()
        {
            RuleFor(r => r.Id).NotEmpty().WithMessage("Please provide Birth Id");
        }

    }
}
