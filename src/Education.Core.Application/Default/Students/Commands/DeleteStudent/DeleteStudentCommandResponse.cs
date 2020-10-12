using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandResponse : ApplicationResponse<Student>
    {
        public DeleteStudentCommandResponse(WrapRequest<Student> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
