using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Core.Application.Default.Classes.Queries.GetClassByID
{
    public class GetClassByIDQueryHandler : IRequestHandler<GetClassByIDQuery, GetClassByIDQueryResponse>
    {
        private IDefaultDbContext Context { get; set; }
        public GetClassByIDQueryHandler(IDefaultDbContext context)
        {
            Context = context;
        }
        public async Task<GetClassByIDQueryResponse> Handle(GetClassByIDQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.ClassID);

            var data = await Context.Classes
                .Where(x => x.ClassID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("Class not found!");
            }

            return new GetClassByIDQueryResponse(request, data, resultCount: 1);
        }
    }
}
