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
    /// Endpoint update property image
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>04/08/2021</date>
    public class Update :BaseAsyncEndpoint.WithRequest<UpdatePropertyImageRequest>.WithResponse<UpdatePropertyImageResponse>
    {
        private readonly IPropertyImageService _propertyService;

        /// <summary>
        /// constructor property update
        /// </summary>
        /// <param name="propertyService">PropertyImage services</param>
        public Update(IPropertyImageService propertyService)
        {
            _propertyService = propertyService;
        }

        /// <summary>
        /// Action update property 
        /// </summary>
        /// <param name="request">Request application</param>
        /// <param name="cancellationToken">Cancellation</param>
        /// <returns></returns>
        [HttpGet("api/update-propertyimage")]
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
