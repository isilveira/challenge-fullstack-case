using Education.Core.Domain.Entities.Default;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Core.Domain.Validations.EntityValidationsDefault
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
        }
    }
}