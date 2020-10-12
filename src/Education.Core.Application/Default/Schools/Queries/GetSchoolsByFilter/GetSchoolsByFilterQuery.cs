using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Schools.Queries.GetSchoolsByFilter
{
    public class GetSchoolsByFilterQuery : ApplicationRequest<School, GetSchoolsByFilterQueryResponse>
    {
        public GetSchoolsByFilterQuery()
        {
            ConfigKeys(x => x.SchoolID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Classes);
            ConfigSuppressedResponseProperties(x => x.Classes);
        }
    }
}
