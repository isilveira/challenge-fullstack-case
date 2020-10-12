using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Core.Application.Default.Schools.Queries.GetSchoolByID
{
    public class GetSchoolByIDQueryHandler : IRequestHandler<GetSchoolByIDQuery, GetSchoolByIDQueryResponse>
    {
        private IDefaultDbContext Context { get; set; }
        public GetSchoolByIDQueryHandler(IDefaultDbContext context)
        {
            Context = context;
        }
        public async Task<GetSchoolByIDQueryResponse> Handle(GetSchoolByIDQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SchoolID);

            var data = await Context.Schools
                .Where(x => x.SchoolID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("School not found!");
            }

            return new GetSchoolByIDQueryResponse(request, data, resultCount: 1);
        }
    }
}
