using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Owner;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Owner
{
    public class Update : BaseAsyncEndpoint.WithRequest<UpdateOwnerRequest>.WithResponse<UpdateOwnerResponse>
    {
        private readonly IOwnerService _ownerService;

        public Update(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPut("api/update-owner")]
        [SwaggerOperation(
        Summary = "Update owner in application",
        Description = "Update onwer",
        OperationId = "owner.update",
        Tags = new[] { "OwnerEndpoints" })]
        public override async Task<ActionResult<UpdateOwnerResponse>> HandleAsync(UpdateOwnerRequest request,
                                                                                  CancellationToken cancellationToken = default)
        {
            return await _ownerService.UpdateOwnerAsync(request, cancellationToken);
        }
    }
}
