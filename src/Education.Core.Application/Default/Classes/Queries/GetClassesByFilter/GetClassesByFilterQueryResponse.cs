using ModelWrapper;
using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Classes.Queries.GetClassesByFilter
{
    public class GetClassesByFilterQueryResponse : ApplicationResponse<Class>
    {
        public GetClassesByFilterQueryResponse(WrapRequest<Class> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
