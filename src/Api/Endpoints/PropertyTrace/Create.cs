using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyTrace;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.PropertyTrace
{
    public class Create : BaseAsyncEndpoint.WithRequest<CreatePropertyTraceRequest>.WithResponse<CreatePropertyTraceResponse>
    {
        private readonly IPropertyTraceService _PropertyTraceService;

        public Create(IPropertyTraceService PropertyTraceService)
        {
            _PropertyTraceService = PropertyTraceService;
        }

        [HttpPost("api/create-propertytrace")]
        [SwaggerOperation(
         Summary = "Create PropertyTrace in application",
         Description = "Create PropertyTrace",
         OperationId = "PropertyTrace.create",
         Tags = new[] { "PropertyTraceEndpoints" })]
        public async override Task<ActionResult<CreatePropertyTraceResponse>> HandleAsync(CreatePropertyTraceRequest request, CancellationToken cancellationToken = default)
        {
            return await _PropertyTraceService.CreatePropertyTraceAsync(request, cancellationToken);
        }
    }
}
