using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Education.Core.Domain.Interfaces.Services.Default.Schools;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Core.Application.Default.Schools.Commands.PostSchool
{
    public class PostSchoolCommandHandler : ApplicationRequestHandler<School, PostSchoolCommand, PostSchoolCommandResponse>
    {
        private IDefaultDbContext Context { get; set; }
        private IPostSchoolService PostService { get; set; }
        public PostSchoolCommandHandler(
            IDefaultDbContext context,
            IPostSchoolService postService
        )
        {
            Context = context;
            PostService = postService;
        }
        public override async Task<PostSchoolCommandResponse> Handle(PostSchoolCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await PostService.Run(data);

            await Context.SaveChangesAsync();

            return new PostSchoolCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
