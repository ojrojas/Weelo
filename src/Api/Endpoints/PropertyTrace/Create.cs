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
    /// Property trace
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>04/08/2021</date>
    public class Create : BaseAsyncEndpoint.WithRequest<CreatePropertyTraceRequest>.WithResponse<CreatePropertyTraceResponse>
    {
        private readonly IPropertyTraceService _PropertyTraceService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="PropertyTraceService">Property services</param>
        public Create(IPropertyTraceService PropertyTraceService)
        {
            _PropertyTraceService = PropertyTraceService;
        }

        /// <summary>
        /// Action create property trace
        /// </summary>
        /// <param name="request">request property</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Property trace created</returns>
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
