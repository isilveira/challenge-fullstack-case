using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Schools.Commands.DeleteSchool
{
    public class DeleteSchoolCommandResponse : ApplicationResponse<School>
    {
        public DeleteSchoolCommandResponse(WrapRequest<School> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
