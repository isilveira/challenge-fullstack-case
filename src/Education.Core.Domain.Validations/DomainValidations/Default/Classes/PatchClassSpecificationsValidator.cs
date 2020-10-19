using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Validations.Specifications.Default.Classes;
using NetDevPack.Specification;

namespace Education.Core.Domain.Validations.DomainValidations.Default.Classes
{
    public class PatchClassSpecificationsValidator : SpecValidator<Class>
    {
        public PatchClassSpecificationsValidator(
            ClassNameAlreadyExistsSpecification classNameAlreadyExistsSpecification,
            ClassCodeAlreadyExistsSpecification classCodeAlreadyExistsSpecification
            )
        {
            base.Add("ClassNameMustBeUnique", new Rule<Class>(classNameAlreadyExistsSpecification.Not(), "Já existe uma Turma com esse nome!"));
            base.Add("ClassCodeMustBeUnique", new Rule<Class>(classCodeAlreadyExistsSpecification.Not(), "Já existe uma Turma com esse Código de Turma!"));
        }
    }
}
