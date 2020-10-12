using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Schools.Queries.GetSchoolByID
{
    public class GetSchoolByIDQuery : ApplicationRequest<School, GetSchoolByIDQueryResponse>
    {
        public GetSchoolByIDQuery()
        {
            ConfigKeys(x => x.SchoolID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Classes);
            ConfigSuppressedResponseProperties(x => x.Classes);
        }
    }
}
