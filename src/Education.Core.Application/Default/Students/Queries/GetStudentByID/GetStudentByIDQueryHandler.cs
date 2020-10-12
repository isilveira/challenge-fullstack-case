using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Core.Application.Default.Students.Queries.GetStudentByID
{
    public class GetStudentByIDQueryHandler : IRequestHandler<GetStudentByIDQuery, GetStudentByIDQueryResponse>
    {
        private IDefaultDbContext Context { get; set; }
        public GetStudentByIDQueryHandler(IDefaultDbContext context)
        {
            Context = context;
        }
        public async Task<GetStudentByIDQueryResponse> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StudentID);

            var data = await Context.Students
                .Where(x => x.StudentID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("Student not found!");
            }

            return new GetStudentByIDQueryResponse(request, data, resultCount: 1);
        }
    }
}
