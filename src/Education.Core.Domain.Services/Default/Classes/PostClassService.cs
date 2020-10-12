using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Education.Core.Domain.Interfaces.Services.Default.Classes;
using Education.Core.Domain.Validations.DomainValidations.Default.Classes;
using Education.Core.Domain.Validations.EntityValidationsDefault;
using System.Threading.Tasks;

namespace Education.Core.Domain.Services.Default.Classes
{
    public class PostClassService : DomainService<Class>, IPostClassService
    {
        private IDefaultDbContext Context { get; set; }
        public PostClassService(
            IDefaultDbContext context,
            ClassValidator entityValidator,
            PostClassSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }
        public override async Task Run(Class entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            await Context.Classes.AddAsync(entity);
        }
    }
}
