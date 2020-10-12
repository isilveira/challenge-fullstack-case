using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Schools.Commands.PatchSchool
{
    public class PatchSchoolCommandResponse : ApplicationResponse<School>
    {
        public PatchSchoolCommandResponse(WrapRequest<School> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
