using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Property
{
    public class Create : BaseAsyncEndpoint.WithRequest<CreatePropertyRequest>.WithResponse<CreatePropertyResponse>
    {
        private readonly IPropertyService _propertyService;

        public Create(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost("api/create-property")]
        [SwaggerOperation(
         Summary = "Create property in application",
         Description = "Create property",
         OperationId = "property.create",
         Tags = new[] { "PropertyEndpoints" })]
        public async override Task<ActionResult<CreatePropertyResponse>> HandleAsync(CreatePropertyRequest request, CancellationToken cancellationToken = default)
        {
            return await _propertyService.CreatePropertyAsync(request, cancellationToken);
        }
    }
}
