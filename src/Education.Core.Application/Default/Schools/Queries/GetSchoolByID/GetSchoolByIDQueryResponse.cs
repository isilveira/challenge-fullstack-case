using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Schools.Queries.GetSchoolByID
{
    public class GetSchoolByIDQueryResponse : ApplicationResponse<School>
    {
        public GetSchoolByIDQueryResponse(WrapRequest<School> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
