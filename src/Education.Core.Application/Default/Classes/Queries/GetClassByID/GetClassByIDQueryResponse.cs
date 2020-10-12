using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Classes.Queries.GetClassByID
{
    public class GetClassByIDQueryResponse : ApplicationResponse<Class>
    {
        public GetClassByIDQueryResponse(WrapRequest<Class> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
