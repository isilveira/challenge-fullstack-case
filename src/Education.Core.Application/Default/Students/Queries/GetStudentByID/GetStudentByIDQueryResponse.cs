using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Students.Queries.GetStudentByID
{
    public class GetStudentByIDQueryResponse : ApplicationResponse<Student>
    {
        public GetStudentByIDQueryResponse(WrapRequest<Student> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
