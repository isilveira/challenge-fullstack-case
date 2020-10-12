using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Education.Core.Domain.Interfaces.Services.Default.Classes;
using Education.Core.Domain.Validations.DomainValidations.Default.Classes;
using Education.Core.Domain.Validations.EntityValidationsDefault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Core.Domain.Services.Default.Classes
{
    public class PatchClassService : DomainService<Class>, IPatchClassService
    {
        private IDefaultDbContext Context { get; set; }
        public PatchClassService(
            IDefaultDbContext context,
            ClassValidator entityValidator,
            PatchClassSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Class entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            return Task.CompletedTask;
        }
    }
}
