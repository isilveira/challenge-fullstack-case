using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Schools.Commands.PutSchool
{
    public class PutSchoolCommandResponse : ApplicationResponse<School>
    {
        public PutSchoolCommandResponse(WrapRequest<School> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
