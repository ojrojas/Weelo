using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyTrace;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.PropertyTrace
{
    public class Delete : BaseAsyncEndpoint.WithRequest<DeletePropertyTraceRequest>.WithResponse<DeletePropertyTraceResponse>
    {
        private readonly IPropertyTraceService _propertyTraceService;

        public Delete(IPropertyTraceService propertyTraceService)
        {
            _propertyTraceService = propertyTraceService;
        }

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
