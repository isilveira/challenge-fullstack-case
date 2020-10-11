using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Services.Default.Samples;

namespace Education.Core.Application.Default.Samples.Commands.PutSample
{
    public class PutSampleCommandHandler : ApplicationRequestHandler<Sample, PutSampleCommand, PutSampleCommandResponse>
    {
        public IDefaultDbContext Context { get; set; }
        private IPutSampleService PutService { get; set; }
        public PutSampleCommandHandler(
            IDefaultDbContext context,
            IPutSampleService putService)
        {
            Context = context;
            PutService = putService;
        }
        public override async Task<PutSampleCommandResponse> Handle(PutSampleCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SampleID);
            var data = await Context.Samples.SingleOrDefaultAsync(x => x.SampleID == id);

            if (data == null)
            {
                throw new Exception("Sample not found!");
            }

            request.Put(data);

            await PutService.Run(data);

            await Context.SaveChangesAsync();

            return new PutSampleCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
