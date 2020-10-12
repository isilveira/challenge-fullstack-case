using Education.Core.Application.Default.Schools.Commands.DeleteSchool;
using Education.Core.Application.Default.Schools.Commands.PatchSchool;
using Education.Core.Application.Default.Schools.Commands.PostSchool;
using Education.Core.Application.Default.Schools.Commands.PutSchool;
using Education.Core.Application.Default.Schools.Queries.GetSchoolByID;
using Education.Core.Application.Default.Schools.Queries.GetSchoolsByFilter;
using Education.Presentations.WebAPP.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Presentations.Resources
{
    public class SchoolsController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetSchoolsByFilterQueryResponse>> Get(GetSchoolsByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpGet("{schoolid}")]
        public async Task<ActionResult<GetSchoolByIDQueryResponse>> Get(GetSchoolByIDQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostSchoolCommandResponse>> Post(PostSchoolCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPut("{schoolid}")]
        public async Task<ActionResult<PutSchoolCommandResponse>> Put(PutSchoolCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPatch("{schoolid}")]
        public async Task<ActionResult<PatchSchoolCommandResponse>> Patch(PatchSchoolCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpDelete("{schoolid}")]
        public async Task<ActionResult<DeleteSchoolCommandResponse>> Delete(DeleteSchoolCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }
    }
}
