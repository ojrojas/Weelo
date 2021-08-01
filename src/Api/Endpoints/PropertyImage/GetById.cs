using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyImage;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.PropertyImage
{
    public class GetById: BaseAsyncEndpoint.WithRequest<GetByIdProertyImageRequest>.WithResponse<GetByIdPropertyImageResponse>
    {

        private readonly IPropertyImageService _propertyService;

        public GetById(IPropertyImageService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPut("api/getbyid-propertyimage/{PropertyImageId}")]
        [SwaggerOperation(
        Summary = "Get by id property images in application",
        Description = "Update property images",
        OperationId = "propertyimage.update",
        Tags = new[] { "PropertyImageEndpoints" })]
        public override async Task<ActionResult<GetByIdPropertyImageResponse>> HandleAsync(GetByIdProertyImageRequest request, CancellationToken cancellationToken = default)
        {
            return await _propertyService.GetPropertyImageByIdAsync(request, cancellationToken);
        }
    }
}
