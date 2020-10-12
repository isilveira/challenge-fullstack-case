using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Core.Application.Default.Schools.Queries.GetSchoolsByFilter
{
    public class GetSchoolsByFilterQueryHandler : IRequestHandler<GetSchoolsByFilterQuery, GetSchoolsByFilterQueryResponse>
    {
        private IDefaultDbContext Context { get; set; }
        public GetSchoolsByFilterQueryHandler(IDefaultDbContext context)
        {
            Context = context;
        }
        public async Task<GetSchoolsByFilterQueryResponse> Handle(GetSchoolsByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;
            
            var data =  await Context.Schools
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            return new GetSchoolsByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
