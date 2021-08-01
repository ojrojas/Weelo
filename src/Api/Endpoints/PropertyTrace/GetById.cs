using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyTrace;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.PropertyTrace
{
    public class GetById: BaseAsyncEndpoint.WithRequest<GetByIdPropertyTraceRequest>.WithResponse<GetByIdPropertyTraceResponse>
    {
        private readonly IPropertyTraceService _propertyService;

        public GetById(IPropertyTraceService propertyService)
        {
            _propertyService = propertyService;
        }

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
