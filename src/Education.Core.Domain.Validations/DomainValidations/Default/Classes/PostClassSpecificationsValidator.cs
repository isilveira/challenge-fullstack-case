using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Validations.Specifications.Default.Classes;
using NetDevPack.Specification;

namespace Education.Core.Domain.Validations.DomainValidations.Default.Classes
{
    public class PostClassSpecificationsValidator : SpecValidator<Class>
    {
        public PostClassSpecificationsValidator(
            ClassNameAlreadyExistsSpecification classNameAlreadyExistsSpecification,
            ClassCodeAlreadyExistsSpecification classCodeAlreadyExistsSpecification
            )
        {
            base.Add("ClassNameMustBeUnique", new Rule<Class>(classNameAlreadyExistsSpecification.Not(), "A register with this name already exists!"));
            base.Add("ClassCodeMustBeUnique", new Rule<Class>(classCodeAlreadyExistsSpecification.Not(), "A register with this code already exists!"));
        }
    }
}
