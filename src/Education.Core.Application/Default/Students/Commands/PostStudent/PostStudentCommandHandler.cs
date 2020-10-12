using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Education.Core.Domain.Interfaces.Services.Default.Students;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Core.Application.Default.Students.Commands.PostStudent
{
    public class PostStudentCommandHandler : ApplicationRequestHandler<Student, PostStudentCommand, PostStudentCommandResponse>
    {
        private IDefaultDbContext Context { get; set; }
        private IPostStudentService PostService { get; set; }
        public PostStudentCommandHandler(
            IDefaultDbContext context,
            IPostStudentService postService
        )
        {
            Context = context;
            PostService = postService;
        }
        public override async Task<PostStudentCommandResponse> Handle(PostStudentCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await PostService.Run(data);

            await Context.SaveChangesAsync();

            return new PostStudentCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
