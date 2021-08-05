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
    /// Endpoint list properties
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>02/08/2021</date>
    public class List : BaseAsyncEndpoint.WithoutRequest.WithResponse<ListPropertyResponse>
    {
        private readonly IPropertyService _propertyService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyService">Service Property</param>
        public List(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        /// <summary>
        /// Action list properties
        /// </summary>
        /// <param name="cancellationToken">cancellation token on fail</param>
        /// <returns>Property list</returns>
        [HttpGet("api/list-property")]
        [SwaggerOperation(
        Summary = "List properties in application",
        Description = "List properties",
        OperationId = "property.list",
        Tags = new[] { "PropertyEndpoints" })]
        public override async Task<ActionResult<ListPropertyResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _propertyService.ListPropertyAsync(cancellationToken);
        }
    }
}
