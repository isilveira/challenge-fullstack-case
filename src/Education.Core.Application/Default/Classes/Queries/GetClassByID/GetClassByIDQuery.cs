using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Classes.Queries.GetClassByID
{
    public class GetClassByIDQuery : ApplicationRequest<Class, GetClassByIDQueryResponse>
    {
        public GetClassByIDQuery()
        {
            ConfigKeys(x => x.ClassID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.School);
            ConfigSuppressedResponseProperties(x => x.School);
        }
    }
}
