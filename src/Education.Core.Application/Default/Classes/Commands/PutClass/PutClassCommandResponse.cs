using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Classes.Commands.PutClass
{
    public class PutClassCommandResponse : ApplicationResponse<Class>
    {
        public PutClassCommandResponse(WrapRequest<Class> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
