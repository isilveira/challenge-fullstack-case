using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Classes.Commands.PostClass
{
    public class PostClassCommandResponse : ApplicationResponse<Class>
    {
        public PostClassCommandResponse(WrapRequest<Class> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
