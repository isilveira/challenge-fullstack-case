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
    public class DeleteStudentService : DomainService<Student>,IDeleteStudentService
    {
        private IDefaultDbContext Context { get; set; }
        public DeleteStudentService(
            IDefaultDbContext context,
            StudentValidator entityValidator,
            DeleteStudentSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Student entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            Context.Students.Remove(entity);

            return Task.CompletedTask;
        }
    }
}
