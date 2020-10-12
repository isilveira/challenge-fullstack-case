using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Education.Core.Domain.Interfaces.Services.Default.Schools;
using Education.Core.Domain.Validations.DomainValidations.Default.Schools;
using Education.Core.Domain.Validations.EntityValidationsDefault;
using System.Threading.Tasks;

namespace Education.Core.Domain.Services.Default.Schools
{
    public class PostSchoolService : DomainService<School>, IPostSchoolService
    {
        private IDefaultDbContext Context { get; set; }
        public PostSchoolService(
            IDefaultDbContext context,
            SchoolValidator entityValidator,
            PostSchoolSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }
        public override async Task Run(School entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            await Context.Schools.AddAsync(entity);
        }
    }
}
