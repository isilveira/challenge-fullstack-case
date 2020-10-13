using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using NetDevPack.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Education.Core.Domain.Validations.Specifications.Default.Classes
{
    public class ClassNameAlreadyExistsSpecification : Specification<Class>
    {
        private IDefaultDbContextQuery Context { get; set; }
        public ClassNameAlreadyExistsSpecification(IDefaultDbContextQuery context)
        {
            Context = context;
        }
        public override Expression<Func<Class, bool>> ToExpression()
        {
            return _class => Context.Classes.Any(x => x.Name == _class.Name && x.ClassID != _class.ClassID);
        }
    }
}
