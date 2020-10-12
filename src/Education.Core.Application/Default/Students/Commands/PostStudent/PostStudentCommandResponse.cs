using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Students.Commands.PostStudent
{
    public class PostStudentCommandResponse : ApplicationResponse<Student>
    {
        public PostStudentCommandResponse(WrapRequest<Student> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
