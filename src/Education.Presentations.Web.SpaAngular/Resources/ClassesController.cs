using Education.Core.Application.Default.Classes.Commands.DeleteClass;
using Education.Core.Application.Default.Classes.Commands.PatchClass;
using Education.Core.Application.Default.Classes.Commands.PostClass;
using Education.Core.Application.Default.Classes.Commands.PutClass;
using Education.Core.Application.Default.Classes.Queries.GetClassByID;
using Education.Core.Application.Default.Classes.Queries.GetClassesByFilter;
using Education.Presentations.Web.SpaAngular.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Presentations.Web.SpaAngular.Resources
{
    public class ClassesController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetClassesByFilterQueryResponse>> Get(GetClassesByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpGet("{classid}")]
        public async Task<ActionResult<GetClassByIDQueryResponse>> Get(GetClassByIDQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostClassCommandResponse>> Post(PostClassCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPut("{classid}")]
        public async Task<ActionResult<PutClassCommandResponse>> Put(PutClassCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPatch("{classid}")]
        public async Task<ActionResult<PatchClassCommandResponse>> Patch(PatchClassCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpDelete("{classid}")]
        public async Task<ActionResult<DeleteClassCommandResponse>> Delete(DeleteClassCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }
    }
}
