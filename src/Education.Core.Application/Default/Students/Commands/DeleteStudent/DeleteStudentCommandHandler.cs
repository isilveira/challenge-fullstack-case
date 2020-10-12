using MediatR;
using Microsoft.EntityFrameworkCore;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Services.Default.Students;

namespace Education.Core.Application.Default.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : ApplicationRequestHandler<Student, DeleteStudentCommand, DeleteStudentCommandResponse>
    {
        public IDefaultDbContext Context { get; set; }
        private IDeleteStudentService DeleteService { get; set; }
        public DeleteStudentCommandHandler(
            IDefaultDbContext context,
            IDeleteStudentService deleteService)
        {
            Context = context;
            DeleteService = deleteService;
        }
        public override async Task<DeleteStudentCommandResponse> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StudentID);

            var data = await Context.Students.SingleOrDefaultAsync(x => x.StudentID == id);

            if (data == null)
                throw new Exception("Student not found!");

            await DeleteService.Run(data);

            await Context.SaveChangesAsync();

            return new DeleteStudentCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
