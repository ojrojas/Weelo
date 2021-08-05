using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyImage;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.PropertyImage
{
    /// <summary>
    /// Endpoint delete property image
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>04/08/2021</date>
    public class Delete : BaseAsyncEndpoint.WithRequest<DeletePropertyImageRequest>.WithResponse<DeletePropertyImageResponse>
    {
        private readonly IPropertyImageService _PropertyImageService;

        /// <summary>
        /// Constructor Property image
        /// </summary>
        /// <param name="PropertyImageService">Property imageservices</param>
        public Delete(IPropertyImageService PropertyImageService)
        {
            _PropertyImageService = PropertyImageService;
        }

        /// <summary>
        /// Action delete property image
        /// </summary>
        /// <param name="request">request property image</param>
        /// <param name="cancellationToken">Cancellation on fail</param>
        /// <returns>Deleted property image</returns>
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
