using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Owner;
using Weelo.Core.Interfaces;

namespace Api.Endpoints.Owner
{
    public class GetOwnerById : BaseAsyncEndpoint.WithRequest<GetOwnerByIdRequest>.WithResponse<GetOwnerByIdResponse>
    {

        private readonly IOwnerService _ownerService;

        public GetOwnerById(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet("api/getbyid-owner/{OwnerId}")]
        [SwaggerOperation(
            Summary = "Get by id owner in application",
            Description = "Get by id onwer",
            OperationId = "owner.getbyid",
            Tags = new[] { "OwnerEndpoints" })]
        public override async Task<ActionResult<GetOwnerByIdResponse>> HandleAsync(GetOwnerByIdRequest request,
                                                                                   CancellationToken cancellationToken = default)
        {
            return await _ownerService.GetOwnerByIdAsync(request, cancellationToken);
        }
    }
}
