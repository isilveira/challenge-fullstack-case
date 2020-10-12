using MediatR;
using Microsoft.EntityFrameworkCore;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Services.Default.Schools;

namespace Education.Core.Application.Default.Schools.Commands.DeleteSchool
{
    public class DeleteSchoolCommandHandler : ApplicationRequestHandler<School, DeleteSchoolCommand, DeleteSchoolCommandResponse>
    {
        public IDefaultDbContext Context { get; set; }
        private IDeleteSchoolService DeleteService { get; set; }
        public DeleteSchoolCommandHandler(
            IDefaultDbContext context,
            IDeleteSchoolService deleteService)
        {
            Context = context;
            DeleteService = deleteService;
        }
        public override async Task<DeleteSchoolCommandResponse> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SchoolID);

            var data = await Context.Schools.SingleOrDefaultAsync(x => x.SchoolID == id);

            if (data == null)
                throw new Exception("School not found!");

            await DeleteService.Run(data);

            await Context.SaveChangesAsync();

            return new DeleteSchoolCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
