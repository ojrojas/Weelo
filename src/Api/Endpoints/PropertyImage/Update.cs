using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyImage;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.PropertyImage
{
    public class Update :BaseAsyncEndpoint.WithRequest<UpdatePropertyImageRequest>.WithResponse<UpdatePropertyImageResponse>
    {
        private readonly IPropertyImageService _propertyService;

        public Update(IPropertyImageService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet("api/update-propertyimage/{PropertyImageId}")]
        [SwaggerOperation(
        Summary = "Update property in application",
        Description = "Update property",
        OperationId = "propertyimage.update",
        Tags = new[] { "PropertyImageEndpoints" })]
        public override async Task<ActionResult<UpdatePropertyImageResponse>> HandleAsync(UpdatePropertyImageRequest request, CancellationToken cancellationToken = default)
        {
            return await _propertyService.UpdatePropertyImageAsync(request, cancellationToken);
        }
    }
}
