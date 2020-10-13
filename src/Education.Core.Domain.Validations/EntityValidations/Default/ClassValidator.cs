using Education.Core.Domain.Entities.Default;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Core.Domain.Validations.EntityValidationsDefault
{
    public class ClassValidator : AbstractValidator<Class>
    {
        public ClassValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{0} cannot be empty!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("{0} must have at least 3 caracters!");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("{0} must have a maximum of 100 caracters!");

            RuleFor(x => x.ClassCode).NotEmpty().WithMessage("{0} cannot be empty!");
            RuleFor(x => x.ClassCode).MinimumLength(3).WithMessage("{0} must have at least 3 caracters!");
            RuleFor(x => x.ClassCode).MaximumLength(100).WithMessage("{0} must have a maximum of 100 caracters!");
        }
    }
}
