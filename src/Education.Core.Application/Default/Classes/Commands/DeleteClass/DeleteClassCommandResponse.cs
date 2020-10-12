using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Classes.Commands.DeleteClass
{
    public class DeleteClassCommandResponse : ApplicationResponse<Class>
    {
        public DeleteClassCommandResponse(WrapRequest<Class> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
