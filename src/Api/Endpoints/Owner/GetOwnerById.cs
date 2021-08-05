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
    /// Get By Id Endpoint Owner
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>03/08/2021</date>
    public class GetOwnerById : BaseAsyncEndpoint.WithRequest<GetOwnerByIdRequest>.WithResponse<GetOwnerByIdResponse>
    {

        private readonly IOwnerService _ownerService;

        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="ownerService">Owner service</param>
        public GetOwnerById(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        /// <summary>
        /// Action getbyid owner
        /// </summary>
        /// <param name="request">Request application</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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
