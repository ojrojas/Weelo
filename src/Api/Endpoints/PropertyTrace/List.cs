using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyTrace;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.PropertyTrace
{
    public class List : BaseAsyncEndpoint.WithRequest<ListPropertyTraceRequest>.WithResponse<ListPropertyTraceResponse>
    {
        private readonly IPropertyTraceService _propertyService;

        public List(IPropertyTraceService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet("api/list-propertytrace/{PropertyId}")]
        [SwaggerOperation(
        Summary = "List properties trace in application",
        Description = "List properties",
        OperationId = "propertytrace.list",
        Tags = new[] { "PropertyTraceEndpoints" })]
        public override async Task<ActionResult<ListPropertyTraceResponse>> HandleAsync(ListPropertyTraceRequest request, CancellationToken cancellationToken = default)
        {
            return await _propertyService.ListPropertyTraceAsync(cancellationToken);
        }
    }
}
