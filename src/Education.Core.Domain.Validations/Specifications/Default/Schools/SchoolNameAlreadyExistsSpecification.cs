using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using NetDevPack.Specification;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Education.Core.Domain.Validations.Specifications.Default.Schools
{
    public class SchoolNameAlreadyExistsSpecification : Specification<School>
    {
        private IDefaultDbContextQuery Context { get; set; }
        public SchoolNameAlreadyExistsSpecification(IDefaultDbContextQuery context)
        {
            Context = context;
        }
        public override Expression<Func<School, bool>> ToExpression()
        {
            return school => Context.Schools.Any(x => x.Name == school.Name && x.SchoolID != school.SchoolID);
        }
    }
}
