using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Owner;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Owner
{
    public class Create : BaseAsyncEndpoint.WithRequest<CreateOwnerRequest>.WithResponse<CreateOwnerResponse>
    {
        private readonly IOwnerService _ownerService;

        public Create(IOwnerService ownerService)
        {
           _ownerService = ownerService;
        }

        [HttpPost("api/create-owner")]
        [SwaggerOperation(
          Summary = "Create owner in application",
          Description = "Create onwer",
          OperationId = "owner.create",
          Tags = new[] { "OwnerEndpoints" })]
        public override async Task<ActionResult<CreateOwnerResponse>> HandleAsync(CreateOwnerRequest request,
                                                                            CancellationToken cancellationToken = default)
        {
            return await _ownerService.CreateOwnerAsync(request, cancellationToken);
        }
    }
}
