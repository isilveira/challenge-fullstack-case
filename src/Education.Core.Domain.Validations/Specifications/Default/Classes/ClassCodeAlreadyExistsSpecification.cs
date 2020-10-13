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
    public class ClassCodeAlreadyExistsSpecification : Specification<Class>
    {
        private IDefaultDbContextQuery Context { get; set; }
        public ClassCodeAlreadyExistsSpecification(IDefaultDbContextQuery context)
        {
            Context = context;
        }
        public override Expression<Func<Class, bool>> ToExpression()
        {
            return _class => Context.Classes.Any(x => x.ClassCode == _class.ClassCode && x.ClassID != _class.ClassID);
        }
    }
}
