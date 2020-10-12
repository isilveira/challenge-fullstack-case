using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Services.Default.Schools;

namespace Education.Core.Application.Default.Schools.Commands.PutSchool
{
    public class PutSchoolCommandHandler : ApplicationRequestHandler<School, PutSchoolCommand, PutSchoolCommandResponse>
    {
        public IDefaultDbContext Context { get; set; }
        private IPutSchoolService PutService { get; set; }
        public PutSchoolCommandHandler(
            IDefaultDbContext context,
            IPutSchoolService putService)
        {
            Context = context;
            PutService = putService;
        }
        public override async Task<PutSchoolCommandResponse> Handle(PutSchoolCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SchoolID);
            var data = await Context.Schools.SingleOrDefaultAsync(x => x.SchoolID == id);

            if (data == null)
            {
                throw new Exception("School not found!");
            }

            request.Put(data);

            await PutService.Run(data);

            await Context.SaveChangesAsync();

            return new PutSchoolCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
