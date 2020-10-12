using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Schools.Queries.GetSchoolsByFilter
{
    public class GetSchoolsByFilterQueryResponse : ApplicationResponse<School>
    {
        public GetSchoolsByFilterQueryResponse(WrapRequest<School> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
