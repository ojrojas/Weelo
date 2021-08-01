using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyImage;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.PropertyImage
{
    public class Create : BaseAsyncEndpoint.WithRequest<CreatePropertyImageRequest>.WithResponse<CreatePropertyImageResponse>
    {
        private readonly IPropertyImageService _PropertyImageService;

        public Create(IPropertyImageService PropertyImageService)
        {
            _PropertyImageService = PropertyImageService;
        }

        [HttpPost("api/create-propertyimage")]
        [SwaggerOperation(
         Summary = "Create PropertyImage in application",
         Description = "Create PropertyImage",
         OperationId = "PropertyImage.create",
         Tags = new[] { "PropertyImageEndpoints" })]
        public async override Task<ActionResult<CreatePropertyImageResponse>> HandleAsync(CreatePropertyImageRequest request, CancellationToken cancellationToken = default)
        {
            return await _PropertyImageService.CreatePropertyImageAsync(request, cancellationToken);
        }
    }
}
