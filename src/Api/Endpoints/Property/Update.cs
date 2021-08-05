using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Property
{
    /// <summary>
    /// Endpoint update property
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>04/08/2021</date>
    public class Update : BaseAsyncEndpoint.WithRequest<UpdatePropertyRequest>.WithResponse<UpdatePropertyResponse>
    {
        private readonly IPropertyService _propertyService;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="propertyService">Property service</param>
        public Update(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        /// <summary>
        /// Action update property 
        /// </summary>
        /// <param name="request">request propertyupdate</param>
        /// <param name="cancellationToken">Cancellation token on fail</param>
        /// <returns>updated property</returns>

        [HttpGet("api/update-property/{PropertyId}")]
        [SwaggerOperation(
        Summary = "Update property in application",
        Description = "Update property",
        OperationId = "property.update",
        Tags = new[] { "PropertyEndpoints" })]
        public override async Task<ActionResult<UpdatePropertyResponse>> HandleAsync(UpdatePropertyRequest request, CancellationToken cancellationToken = default)
        {
            return await _propertyService.UpdatePropertyAsync(request, cancellationToken);
        }
    }
}
