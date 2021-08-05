using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Owner;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Owner
{
    [Authorize]
    /// <summary>
    /// Endpoint Owner Delete
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>04/08/2021</date>
    public class Delete : BaseAsyncEndpoint.WithRequest<DeleteOwnerRequest>.WithResponse<DeleteOwnerResponse>
    {
        private readonly IOwnerService _onwerService;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="onwerService">service owner</param>
        public Delete(IOwnerService onwerService)
        {
            _onwerService = onwerService;
        }

        /// <summary>
        /// Action Delete Owner
        /// </summary>
        /// <param name="request">request application</param>
        /// <param name="cancellationToken">cancellation token on fail</param>
        /// <returns>Delete owner</returns>
        [HttpDelete("api/delete-owner/{OwnerId}")]
        [SwaggerOperation(
            Summary = "Delete owner in application",
            Description = "Delete onwer",
            OperationId = "owner.delete",
            Tags = new[] { "OwnerEndpoints" })]
        public override async Task<ActionResult<DeleteOwnerResponse>> HandleAsync([FromRoute] DeleteOwnerRequest request, CancellationToken cancellationToken = default)
        {
            return await _onwerService.DeleteOwnerAsync(request, cancellationToken);
        }
    }
}
