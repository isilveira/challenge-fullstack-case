using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Services.Default.Students;

namespace Education.Core.Application.Default.Students.Commands.PatchStudent
{
    public class PatchStudentCommandHandler : ApplicationRequestHandler<Student, PatchStudentCommand, PatchStudentCommandResponse>
    {
        public IDefaultDbContext Context { get; set; }
        private IPatchStudentService PatchService { get; set; }
        public PatchStudentCommandHandler(
            IDefaultDbContext context,
            IPatchStudentService patchService)
        {
            Context = context;
            PatchService = patchService;
        }
        public override async Task<PatchStudentCommandResponse> Handle(PatchStudentCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StudentID);

            var data = await Context.Students.SingleOrDefaultAsync(x => x.StudentID == id);

            if (data == null)
            {
                throw new Exception("Student not found!");
            }

            request.Patch(data);

            await PatchService.Run(data);

            await Context.SaveChangesAsync();

            return new PatchStudentCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
