using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Owner;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Owner
{
    public class Delete : BaseAsyncEndpoint.WithRequest<DeleteOwnerRequest>.WithResponse<DeleteOwnerResponse>
    {
        private readonly IOwnerService _onwerService;

        public Delete(IOwnerService onwerService)
        {
            _onwerService = onwerService;
        }

        [HttpDelete("api/delete-owner/{OwnerId}")]
        [SwaggerOperation(
            Summary = "Delete owner in application",
            Description = "Delete onwer",
            OperationId = "owner.delete",
            Tags = new[] { "OwnerEndpoints" })]
        public override Task<ActionResult<DeleteOwnerResponse>> HandleAsync(DeleteOwnerRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
