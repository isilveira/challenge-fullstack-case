using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Classes.Queries.GetClassesByFilter
{
    public class GetClassesByFilterQuery : ApplicationRequest<Class, GetClassesByFilterQueryResponse>
    {
        public GetClassesByFilterQuery()
        {
            ConfigKeys(x => x.ClassID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.School);
            ConfigSuppressedProperties(x => x.Students);
            ConfigSuppressedResponseProperties(x => x.School);
            ConfigSuppressedResponseProperties(x => x.Students);
        }
    }
}
