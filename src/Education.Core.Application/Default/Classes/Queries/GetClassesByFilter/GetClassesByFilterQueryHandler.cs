using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Core.Application.Default.Classes.Queries.GetClassesByFilter
{
    public class GetClassesByFilterQueryHandler : IRequestHandler<GetClassesByFilterQuery, GetClassesByFilterQueryResponse>
    {
        private IDefaultDbContext Context { get; set; }
        public GetClassesByFilterQueryHandler(IDefaultDbContext context)
        {
            Context = context;
        }
        public async Task<GetClassesByFilterQueryResponse> Handle(GetClassesByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;
            
            var data =  await Context.Classes
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            return new GetClassesByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
