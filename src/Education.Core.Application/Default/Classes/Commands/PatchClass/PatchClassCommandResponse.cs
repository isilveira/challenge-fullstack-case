using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Classes.Commands.PatchClass
{
    public class PatchClassCommandResponse : ApplicationResponse<Class>
    {
        public PatchClassCommandResponse(WrapRequest<Class> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
