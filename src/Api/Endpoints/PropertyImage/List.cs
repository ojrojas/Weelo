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
    /// Endpont list properties image
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>04/08/2021</date>
    public class List : BaseAsyncEndpoint.WithRequest<ListPropertyImageRequest>.WithResponse<ListPropertyImageResponse>
    {
        private readonly IPropertyImageService _propertyService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyService">Property service</param>
        public List(IPropertyImageService propertyService)
        {
            _propertyService = propertyService;
        }

        /// <summary>
        /// Action list properties
        /// </summary>
        /// <param name="request">Request application</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Listed properties</returns>
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
