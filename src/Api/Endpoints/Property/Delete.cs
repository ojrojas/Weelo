using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Property
{
    /// <summary>
    /// Endpoitn delte property 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>03/08/2021</date>
    public class Delete : BaseAsyncEndpoint.WithRequest<DeletePropertyRequest>.WithResponse<DeletePropertyResponse>
    {
        private readonly IPropertyService _propertyService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyService">Property service</param>
        public Delete(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        /// <summary>
        /// Action delete property
        /// </summary>
        /// <param name="request">request application</param>
        /// <param name="cancellationToken">cancellation token on fail</param>
        /// <returns>Delete property</returns>
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
