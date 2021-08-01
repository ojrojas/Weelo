using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Property
{
    public class Update : BaseAsyncEndpoint.WithRequest<UpdatePropertyRequest>.WithResponse<UpdatePropertyResponse>
    {
        private readonly IPropertyService _propertyService;

        public Update(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

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
