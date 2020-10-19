using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Validations.Specifications.Default.Schools;
using NetDevPack.Specification;

namespace Education.Core.Domain.Validations.DomainValidations.Default.Schools
{
    public class PostSchoolSpecificationsValidator : SpecValidator<School>
    {
        public PostSchoolSpecificationsValidator(
            SchoolNameAlreadyExistsSpecification schoolNameAlreadyExistsSpecification
        )
        {
            base.Add("SchoolNameMustBeUnique", new Rule<School>(schoolNameAlreadyExistsSpecification.Not(), "J� existe uma Escola com esse nome!"));
        }
    }
}
