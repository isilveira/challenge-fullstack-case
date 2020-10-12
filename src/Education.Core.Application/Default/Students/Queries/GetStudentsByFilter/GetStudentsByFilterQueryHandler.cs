using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Core.Application.Default.Students.Queries.GetStudentsByFilter
{
    public class GetStudentsByFilterQueryHandler : IRequestHandler<GetStudentsByFilterQuery, GetStudentsByFilterQueryResponse>
    {
        private IDefaultDbContext Context { get; set; }
        public GetStudentsByFilterQueryHandler(IDefaultDbContext context)
        {
            Context = context;
        }
        public async Task<GetStudentsByFilterQueryResponse> Handle(GetStudentsByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;
            
            var data =  await Context.Students
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            return new GetStudentsByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
