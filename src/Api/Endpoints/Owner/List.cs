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
    /// List Owner Endpoint
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>03/08/2021</date>
    public class List : BaseAsyncEndpoint.WithoutRequest.WithResponse<ListOwnerResponse>
    {
        private readonly IOwnerService _ownerService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ownerService">Owner service</param>
        public List(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        /// <summary>
        /// Action List Owners 
        /// </summary>
        /// <param name="cancellationToken">Cancellation token on fail</param>
        /// <returns></returns>
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
