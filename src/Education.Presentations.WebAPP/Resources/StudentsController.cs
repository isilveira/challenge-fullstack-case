using Education.Core.Application.Default.Students.Commands.DeleteStudent;
using Education.Core.Application.Default.Students.Commands.PatchStudent;
using Education.Core.Application.Default.Students.Commands.PostStudent;
using Education.Core.Application.Default.Students.Commands.PutStudent;
using Education.Core.Application.Default.Students.Queries.GetStudentByID;
using Education.Core.Application.Default.Students.Queries.GetStudentsByFilter;
using Education.Presentations.WebAPP.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Presentations.Resources
{
    public class StudentsController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetStudentsByFilterQueryResponse>> Get(GetStudentsByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpGet("{studentid}")]
        public async Task<ActionResult<GetStudentByIDQueryResponse>> Get(GetStudentByIDQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostStudentCommandResponse>> Post(PostStudentCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPut("{studentid}")]
        public async Task<ActionResult<PutStudentCommandResponse>> Put(PutStudentCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPatch("{studentid}")]
        public async Task<ActionResult<PatchStudentCommandResponse>> Patch(PatchStudentCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpDelete("{studentid}")]
        public async Task<ActionResult<DeleteStudentCommandResponse>> Delete(DeleteStudentCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }
    }
}
