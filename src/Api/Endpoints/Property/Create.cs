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
    /// Create endpoint Property
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>03/08/2021</date>
    public class Create : BaseAsyncEndpoint.WithRequest<CreatePropertyRequest>.WithResponse<CreatePropertyResponse>
    {
        private readonly IPropertyService _propertyService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyService">Property service</param>
        public Create(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }


        /// <summary>
        /// Action create property
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Created property</returns>
        [HttpPost("api/create-property")]
        [SwaggerOperation(
         Summary = "Create property in application",
         Description = "Create property",
         OperationId = "property.create",
         Tags = new[] { "PropertyEndpoints" })]
        public async override Task<ActionResult<CreatePropertyResponse>> HandleAsync(CreatePropertyRequest request, CancellationToken cancellationToken = default)
        {
            return await _propertyService.CreatePropertyAsync(request, cancellationToken);
        }
    }
}
