using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyTrace;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.PropertyTrace
{
    /// <summary>
    /// Property update trace
    /// </summary>
    public class Update :BaseAsyncEndpoint.WithRequest<UpdatePropertyTraceRequest>.WithResponse<UpdatePropertyTraceResponse>
    {
        private readonly IPropertyTraceService _propertyService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyService">Property trace service</param>
        public Update(IPropertyTraceService propertyService)
        {
            _propertyService = propertyService;
        }

        /// <summary>
        /// Action update property trac
        /// </summary>
        /// <param name="request">Property requested</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>updated property </returns>
        [HttpGet("api/update-propertytrace")]
        [SwaggerOperation(
        Summary = "Update property trace in application",
        Description = "Update property trace",
        OperationId = "propertytrace.update",
        Tags = new[] { "PropertyTraceEndpoints" })]
        public override async Task<ActionResult<UpdatePropertyTraceResponse>> HandleAsync(UpdatePropertyTraceRequest request, CancellationToken cancellationToken = default)
        {
            return await _propertyService.UpdatePropertyTraceAsync(request, cancellationToken);
        }
    }
}
