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
    /// Endpoint list properties trace
    /// </summary>
    /// <author>Oscar Julian Rojas </author>
    /// <date>03/08/2021</date>
    public class List : BaseAsyncEndpoint.WithoutRequest.WithResponse<ListPropertyTraceResponse>
    {
        private readonly IPropertyTraceService _propertyService;

        /// <summary>
        /// Construnctor
        /// </summary>
        /// <param name="propertyService">Property services</param>
        public List(IPropertyTraceService propertyService)
        {
            _propertyService = propertyService;
        }


        /// <summary>
        /// Action listed properties
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Listed properties</returns>
        [HttpGet("api/list-propertytrace")]
        [SwaggerOperation(
        Summary = "List properties trace in application",
        Description = "List properties",
        OperationId = "propertytrace.list",
        Tags = new[] { "PropertyTraceEndpoints" })]
        public override async Task<ActionResult<ListPropertyTraceResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _propertyService.ListPropertyTraceAsync(cancellationToken);
        }
    }
}
