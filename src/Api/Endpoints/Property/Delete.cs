using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Property
{
    public class Delete : BaseAsyncEndpoint.WithRequest<DeletePropertyRequest>.WithResponse<DeletePropertyResponse>
    {
        private readonly IPropertyService _propertyService;

        public Delete(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet("api/delete-property/{PropertyId}")]
        [SwaggerOperation(
         Summary = "Delete property in application",
         Description = "Delete property",
         OperationId = "property.delete",
         Tags = new[] { "PropertyEndpoints" })]
        public async override Task<ActionResult<DeletePropertyResponse>> HandleAsync(DeletePropertyRequest request, CancellationToken cancellationToken = default)
        {
            return await _propertyService.DeletePropertyAsync(request, cancellationToken);
        }
    }
}
