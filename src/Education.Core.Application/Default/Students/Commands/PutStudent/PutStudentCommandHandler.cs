using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Services.Default.Students;

namespace Education.Core.Application.Default.Students.Commands.PutStudent
{
    public class PutStudentCommandHandler : ApplicationRequestHandler<Student, PutStudentCommand, PutStudentCommandResponse>
    {
        public IDefaultDbContext Context { get; set; }
        private IPutStudentService PutService { get; set; }
        public PutStudentCommandHandler(
            IDefaultDbContext context,
            IPutStudentService putService)
        {
            Context = context;
            PutService = putService;
        }
        public override async Task<PutStudentCommandResponse> Handle(PutStudentCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StudentID);
            var data = await Context.Students.SingleOrDefaultAsync(x => x.StudentID == id);

            if (data == null)
            {
                throw new Exception("Student not found!");
            }

            request.Put(data);

            await PutService.Run(data);

            await Context.SaveChangesAsync();

            return new PutStudentCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
