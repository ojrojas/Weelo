using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Owner;
using Weelo.Core.Interfaces;

namespace Api.Endpoints.Owner
{
    public class List : BaseAsyncEndpoint.WithoutRequest.WithResponse<ListOwnerResponse>
    {
        private readonly IOwnerService _ownerService;

        public List(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet("api/list-owners")]
        [SwaggerOperation(
         Summary = "List owners in application",
         Description = "List onwers",
         OperationId = "owner.list",
         Tags = new[] { "OwnerEndpoints" })]
        public override async Task<ActionResult<ListOwnerResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _ownerService.ListOwnerAsync(cancellationToken);
        }
    }
}
