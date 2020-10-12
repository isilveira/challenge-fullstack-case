using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Schools.Commands.PostSchool
{
    public class PostSchoolCommandResponse : ApplicationResponse<School>
    {
        public PostSchoolCommandResponse(WrapRequest<School> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
