using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Education.Core.Domain.Interfaces.Services.Default.Classes;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Core.Application.Default.Classes.Commands.PostClass
{
    public class PostClassCommandHandler : ApplicationRequestHandler<Class, PostClassCommand, PostClassCommandResponse>
    {
        private IDefaultDbContext Context { get; set; }
        private IPostClassService PostService { get; set; }
        public PostClassCommandHandler(
            IDefaultDbContext context,
            IPostClassService postService
        )
        {
            Context = context;
            PostService = postService;
        }
        public override async Task<PostClassCommandResponse> Handle(PostClassCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await PostService.Run(data);

            await Context.SaveChangesAsync();

            return new PostClassCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
