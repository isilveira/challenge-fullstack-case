using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Education.Core.Domain.Interfaces.Services.Default.Schools;
using Education.Core.Domain.Validations.DomainValidations.Default.Schools;
using Education.Core.Domain.Validations.EntityValidationsDefault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Core.Domain.Services.Default.Schools
{
    public class DeleteSchoolService : DomainService<School>,IDeleteSchoolService
    {
        private IDefaultDbContext Context { get; set; }
        public DeleteSchoolService(
            IDefaultDbContext context,
            SchoolValidator entityValidator,
            DeleteSchoolSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(School entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            Context.Schools.Remove(entity);

            return Task.CompletedTask;
        }
    }
}
