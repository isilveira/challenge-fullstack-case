using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Education.Core.Domain.Interfaces.Services.Default.Students;
using Education.Core.Domain.Validations.DomainValidations.Default.Students;
using Education.Core.Domain.Validations.EntityValidationsDefault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Core.Domain.Services.Default.Students
{
    public class PutStudentService : DomainService<Student>, IPutStudentService
    {
        private IDefaultDbContext Context { get; set; }
        public PutStudentService(
            IDefaultDbContext context,
            StudentValidator entityValidator,
            PutStudentSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Student entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            return Task.CompletedTask;
        }
    }
}
