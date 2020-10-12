using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Students.Commands.PatchStudent
{
    public class PatchStudentCommandResponse : ApplicationResponse<Student>
    {
        public PatchStudentCommandResponse(WrapRequest<Student> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
