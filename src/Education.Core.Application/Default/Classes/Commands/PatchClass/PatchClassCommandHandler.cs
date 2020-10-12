using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Services.Default.Classes;

namespace Education.Core.Application.Default.Classes.Commands.PatchClass
{
    public class PatchClassCommandHandler : ApplicationRequestHandler<Class, PatchClassCommand, PatchClassCommandResponse>
    {
        public IDefaultDbContext Context { get; set; }
        private IPatchClassService PatchService { get; set; }
        public PatchClassCommandHandler(
            IDefaultDbContext context,
            IPatchClassService patchService)
        {
            Context = context;
            PatchService = patchService;
        }
        public override async Task<PatchClassCommandResponse> Handle(PatchClassCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.ClassID);

            var data = await Context.Classes.SingleOrDefaultAsync(x => x.ClassID == id);

            if (data == null)
            {
                throw new Exception("Class not found!");
            }

            request.Patch(data);

            await PatchService.Run(data);

            await Context.SaveChangesAsync();

            return new PatchClassCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
