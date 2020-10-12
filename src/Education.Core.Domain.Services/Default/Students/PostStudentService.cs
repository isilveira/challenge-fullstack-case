using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Education.Core.Domain.Interfaces.Services.Default.Students;
using Education.Core.Domain.Validations.DomainValidations.Default.Students;
using Education.Core.Domain.Validations.EntityValidationsDefault;
using System.Threading.Tasks;

namespace Education.Core.Domain.Services.Default.Students
{
    public class PostStudentService : DomainService<Student>, IPostStudentService
    {
        private IDefaultDbContext Context { get; set; }
        public PostStudentService(
            IDefaultDbContext context,
            StudentValidator entityValidator,
            PostStudentSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }
        public override async Task Run(Student entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            await Context.Students.AddAsync(entity);
        }
    }
}
