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
    public class DeleteClassService : DomainService<Class>,IDeleteClassService
    {
        private IDefaultDbContext Context { get; set; }
        public DeleteClassService(
            IDefaultDbContext context,
            ClassValidator entityValidator,
            DeleteClassSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Class entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            Context.Classes.Remove(entity);

            return Task.CompletedTask;
        }
    }
}
