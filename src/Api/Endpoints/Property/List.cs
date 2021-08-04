using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Property
{
    public class List : BaseAsyncEndpoint.WithoutRequest.WithResponse<ListPropertyResponse>
    {
        private readonly IPropertyService _propertyService;

        public List(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

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
