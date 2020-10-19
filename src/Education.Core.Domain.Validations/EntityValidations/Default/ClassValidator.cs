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
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome n�o pode estar vazio!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Nome deve ter pelo menos 3 caracteres!");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Nome deve ter no m�ximo 100 caracteres!");

            RuleFor(x => x.ClassCode).NotEmpty().WithMessage("C�digo da Turma n�o pode estar vazio!");
            RuleFor(x => x.ClassCode).MinimumLength(3).WithMessage("C�digo da Turma deve ter pelo menos 3 caracteres!");
            RuleFor(x => x.ClassCode).MaximumLength(100).WithMessage("C�digo da Turma deve ter no m�ximo 100 caracteres!");

            RuleFor(x => x.SchoolID).NotEmpty().WithMessage("Escola n�o pode estar vazio!");
            RuleFor(x => x.SchoolID).GreaterThan(0).WithMessage("Sele��o da Escola � obrigat�rio!");
        }
    }
}
