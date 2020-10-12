using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Services.Default.Classes;

namespace Education.Core.Application.Default.Classes.Commands.PutClass
{
    public class PutClassCommandHandler : ApplicationRequestHandler<Class, PutClassCommand, PutClassCommandResponse>
    {
        public IDefaultDbContext Context { get; set; }
        private IPutClassService PutService { get; set; }
        public PutClassCommandHandler(
            IDefaultDbContext context,
            IPutClassService putService)
        {
            Context = context;
            PutService = putService;
        }
        public override async Task<PutClassCommandResponse> Handle(PutClassCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.ClassID);
            var data = await Context.Classes.SingleOrDefaultAsync(x => x.ClassID == id);

            if (data == null)
            {
                throw new Exception("Class not found!");
            }

            request.Put(data);

            await PutService.Run(data);

            await Context.SaveChangesAsync();

            return new PutClassCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
