using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Owner;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Owner
{
    [Authorize]
    /// <summary>
    /// Create endpoint Owners
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>02/08/2021</date>
    public class Create : BaseAsyncEndpoint.WithRequest<CreateOwnerRequest>.WithResponse<CreateOwnerResponse>
    {
        private readonly IOwnerService _ownerService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ownerService">service owner </param>
        public Create(IOwnerService ownerService)
        {
           _ownerService = ownerService;
        }

        /// <summary>
        /// Action create owner
        /// </summary>
        /// <param name="request">request application</param>
        /// <param name="cancellationToken">cancellation on fail request</param>
        /// <returns>Owner Create</returns>
        [HttpPost("api/create-owner")]
        [RequestSizeLimit(1_000_000)]
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
