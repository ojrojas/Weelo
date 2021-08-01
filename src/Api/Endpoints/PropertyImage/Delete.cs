using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyImage;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.PropertyImage
{
    public class Delete : BaseAsyncEndpoint.WithRequest<DeletePropertyImageRequest>.WithResponse<DeletePropertyImageResponse>
    {
        private readonly IPropertyImageService _PropertyImageService;

        public Delete(IPropertyImageService PropertyImageService)
        {
            _PropertyImageService = PropertyImageService;
        }

        [HttpGet("api/delete-propertyimage/{PropertyImageId}")]
        [SwaggerOperation(
         Summary = "Delete PropertyImage in application",
         Description = "Delete PropertyImage",
         OperationId = "Propertyimage.delete",
         Tags = new[] { "PropertyImageEndpoints" })]
        public async override Task<ActionResult<DeletePropertyImageResponse>> HandleAsync(DeletePropertyImageRequest request, CancellationToken cancellationToken = default)
        {
            return await _PropertyImageService.DeletePropertyImageAsync(request, cancellationToken);
        }
    }
}
