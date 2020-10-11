using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Education.Core.Domain.Interfaces.Services.Default.Samples;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Core.Application.Default.Samples.Commands.PostSample
{
    public class PostSampleCommandHandler : ApplicationRequestHandler<Sample, PostSampleCommand, PostSampleCommandResponse>
    {
        private IDefaultDbContext Context { get; set; }
        private IPostSampleService PostService { get; set; }
        public PostSampleCommandHandler(
            IDefaultDbContext context,
            IPostSampleService postService
        )
        {
            Context = context;
            PostService = postService;
        }
        public override async Task<PostSampleCommandResponse> Handle(PostSampleCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await PostService.Run(data);

            await Context.SaveChangesAsync();

            return new PostSampleCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
