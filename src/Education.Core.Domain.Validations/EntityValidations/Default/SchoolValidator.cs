using Education.Core.Domain.Entities.Default;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Core.Domain.Validations.EntityValidationsDefault
{
    public class SchoolValidator : AbstractValidator<School>
    {
        public SchoolValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome não pode estar vazio!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Nome deve ter pelo menos 3 caracteres!");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres!");
        }
    }
}
