using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Validations.Specifications.Default.Schools;
using NetDevPack.Specification;

namespace Education.Core.Domain.Validations.DomainValidations.Default.Schools
{
    public class PutSchoolSpecificationsValidator : SpecValidator<School>
    {
        public PutSchoolSpecificationsValidator(
            SchoolNameAlreadyExistsSpecification schoolNameAlreadyExistsSpecification
        )
        {
            base.Add("SchoolNameMustBeUnique", new Rule<School>(schoolNameAlreadyExistsSpecification.Not(), "A register with this name already exists!"));
        }
    }
}
