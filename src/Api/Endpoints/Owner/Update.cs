using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Owner;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Owner
{
    /// <summary>
    /// Update Owner Endpoint
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>03/08/2021</date>
    public class Update : BaseAsyncEndpoint.WithRequest<UpdateOwnerRequest>.WithResponse<UpdateOwnerResponse>
    {
        private readonly IOwnerService _ownerService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ownerService">Owner Services</param>
        public Update(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }


        /// <summary>
        /// Action update owner service
        /// </summary>
        /// <param name="request">Request application</param>
        /// <param name="cancellationToken">Cancellation on fail</param>
        /// <returns></returns>
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
