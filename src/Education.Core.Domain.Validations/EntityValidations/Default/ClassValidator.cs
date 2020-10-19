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
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome não pode estar vazio!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Nome deve ter pelo menos 3 caracteres!");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres!");

            RuleFor(x => x.ClassCode).NotEmpty().WithMessage("Código da Turma não pode estar vazio!");
            RuleFor(x => x.ClassCode).MinimumLength(3).WithMessage("Código da Turma deve ter pelo menos 3 caracteres!");
            RuleFor(x => x.ClassCode).MaximumLength(100).WithMessage("Código da Turma deve ter no máximo 100 caracteres!");

            RuleFor(x => x.SchoolID).NotEmpty().WithMessage("Escola não pode estar vazio!");
            RuleFor(x => x.SchoolID).GreaterThan(0).WithMessage("Seleção da Escola é obrigatório!");
        }
    }
}
