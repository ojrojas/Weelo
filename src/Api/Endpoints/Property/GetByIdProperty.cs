using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Property
{
    [Authorize]
    /// <summary>
    /// Endpoint get by id property 
    /// </summary>
    /// <author>oscar Julian Rojas</author>
    /// <date>02/08/2021</date>
    public class GetByIdProperty : BaseAsyncEndpoint.WithRequest<GetByIdProertyRequest>.WithResponse<GetPropertyByIdResponse>
    {

        private readonly IPropertyService _propertyService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyService">Property service</param>
        public GetByIdProperty(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }


        /// <summary>
        /// Action getbyid property
        /// </summary>
        /// <param name="request">Request application</param>
        /// <param name="cancellationToken">Cancellation token on fail</param>
        /// <returns>Property request</returns>
        [HttpPut("api/getbyid-owner/{OwnerId}")]
        [SwaggerOperation(
        Summary = "Get by id property in application",
        Description = "Update property",
        OperationId = "property.update",
        Tags = new[] { "PropertyEndpoints" })]
        public override async Task<ActionResult<GetPropertyByIdResponse>> HandleAsync([FromRoute] GetByIdProertyRequest request, CancellationToken cancellationToken = default)
        {
            return await _propertyService.GetPropertyByIdAsync(request, cancellationToken);
        }
    }
}
