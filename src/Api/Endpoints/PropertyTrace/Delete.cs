using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyTrace;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.PropertyTrace
{
    [Authorize]
    /// <summary>
    /// Endpoint delete property trace
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>04/08/2021</date>
    public class Delete : BaseAsyncEndpoint.WithRequest<DeletePropertyTraceRequest>.WithResponse<DeletePropertyTraceResponse>
    {
        private readonly IPropertyTraceService _propertyTraceService;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="propertyTraceService">Property trace services</param>
        public Delete(IPropertyTraceService propertyTraceService)
        {
            _propertyTraceService = propertyTraceService;
        }

        /// <summary>
        /// Action delete property trace
        /// </summary>
        /// <param name="request">Rquest property trace</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Delete property</returns>
        [HttpGet("api/delete-propertytrace/{PropertyTraceId}")]
        [SwaggerOperation(
         Summary = "Delete property trace in application",
         Description = "Delete Property trace",
         OperationId = "propertytrace.delete",
         Tags = new[] { "PropertyTraceEndpoints" })]
        public async override Task<ActionResult<DeletePropertyTraceResponse>> HandleAsync(DeletePropertyTraceRequest request, CancellationToken cancellationToken = default)
        {
            return await _propertyTraceService.DeletePropertyTraceAsync(request, cancellationToken);
        }
    }
}
