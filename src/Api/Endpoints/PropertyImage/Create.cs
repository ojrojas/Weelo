using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyImage;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.PropertyImage
{
    [Authorize]
    /// <summary>
    /// Endpoint create property image
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>04/08/2021</date>
    public class Create : BaseAsyncEndpoint.WithRequest<CreatePropertyImageRequest>.WithResponse<CreatePropertyImageResponse>
    {
        private readonly IPropertyImageService _PropertyImageService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="PropertyImageService">Property service image</param>
        public Create(IPropertyImageService PropertyImageService)
        {
            _PropertyImageService = PropertyImageService;
        }

        /// <summary>
        /// Action create property image
        /// </summary>
        /// <param name="request">request image</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>PropertyImage created</returns>
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
