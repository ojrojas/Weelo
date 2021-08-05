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
    /// Endpoint getbyid property trace
    /// </summary>
    /// <author>Oscar julian Rojas</author>
    /// <date>03/08/2021</date>
    public class GetById: BaseAsyncEndpoint.WithRequest<GetByIdPropertyTraceRequest>.WithResponse<GetByIdPropertyTraceResponse>
    {
        private readonly IPropertyTraceService _propertyService;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="propertyService">Property trace service</param>
        public GetById(IPropertyTraceService propertyService)
        {
            _propertyService = propertyService;
        }

        /// <summary>
        /// Action get by id property trace
        /// </summary>
        /// <param name="request">request property </param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Property requested</returns>
        [HttpPut("api/getbyid-propertyTrace/{PropertyTraceId}")]
        [SwaggerOperation(
        Summary = "Get by id property trace in application",
        Description = "Update property",
        OperationId = "propertytrace.update",
        Tags = new[] { "PropertyTraceEndpoints" })]
        public override async Task<ActionResult<GetByIdPropertyTraceResponse>> HandleAsync(GetByIdPropertyTraceRequest request, CancellationToken cancellationToken = default)
        {
            return await _propertyService.GetByIdPropertyTraceAsync(request, cancellationToken);
        }
    }
}
