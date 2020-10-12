using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Students.Commands.PutStudent
{
    public class PutStudentCommandResponse : ApplicationResponse<Student>
    {
        public PutStudentCommandResponse(WrapRequest<Student> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
