using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyImage;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.PropertyImage
{
    public class List : BaseAsyncEndpoint.WithRequest<ListPropertyImageRequest>.WithResponse<ListPropertyImageResponse>
    {
        private readonly IPropertyImageService _propertyService;

        public List(IPropertyImageService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet("api/list-propertyimage")]
        [SwaggerOperation(
        Summary = "List properties image in application",
        Description = "List properties images",
        OperationId = "propertyimage.list",
        Tags = new[] { "PropertyImageEndpoints" })]
        public override async Task<ActionResult<ListPropertyImageResponse>> HandleAsync(ListPropertyImageRequest request, CancellationToken cancellationToken = default)
        {
            return await _propertyService.ListPropertyImageAsync(cancellationToken);
        }
    }
}
