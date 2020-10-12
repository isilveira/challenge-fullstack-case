using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Students.Queries.GetStudentsByFilter
{
    public class GetStudentsByFilterQueryResponse : ApplicationResponse<Student>
    {
        public GetStudentsByFilterQueryResponse(WrapRequest<Student> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
