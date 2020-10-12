using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Services.Default.Schools;

namespace Education.Core.Application.Default.Schools.Commands.PatchSchool
{
    public class PatchSchoolCommandHandler : ApplicationRequestHandler<School, PatchSchoolCommand, PatchSchoolCommandResponse>
    {
        public IDefaultDbContext Context { get; set; }
        private IPatchSchoolService PatchService { get; set; }
        public PatchSchoolCommandHandler(
            IDefaultDbContext context,
            IPatchSchoolService patchService)
        {
            Context = context;
            PatchService = patchService;
        }
        public override async Task<PatchSchoolCommandResponse> Handle(PatchSchoolCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SchoolID);

            var data = await Context.Schools.SingleOrDefaultAsync(x => x.SchoolID == id);

            if (data == null)
            {
                throw new Exception("School not found!");
            }

            request.Patch(data);

            await PatchService.Run(data);

            await Context.SaveChangesAsync();

            return new PatchSchoolCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
