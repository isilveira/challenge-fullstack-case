using MediatR;
using Microsoft.EntityFrameworkCore;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Services.Default.Classes;

namespace Education.Core.Application.Default.Classes.Commands.DeleteClass
{
    public class DeleteClassCommandHandler : ApplicationRequestHandler<Class, DeleteClassCommand, DeleteClassCommandResponse>
    {
        public IDefaultDbContext Context { get; set; }
        private IDeleteClassService DeleteService { get; set; }
        public DeleteClassCommandHandler(
            IDefaultDbContext context,
            IDeleteClassService deleteService)
        {
            Context = context;
            DeleteService = deleteService;
        }
        public override async Task<DeleteClassCommandResponse> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.ClassID);

            var data = await Context.Classes.SingleOrDefaultAsync(x => x.ClassID == id);

            if (data == null)
                throw new Exception("Class not found!");

            await DeleteService.Run(data);

            await Context.SaveChangesAsync();

            return new DeleteClassCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
