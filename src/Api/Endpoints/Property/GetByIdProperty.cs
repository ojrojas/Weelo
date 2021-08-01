using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Property
{
    public class GetByIdProperty : BaseAsyncEndpoint.WithRequest<GetByIdProertyRequest>.WithResponse<GetPropertyByIdResponse>
    {

        private readonly IPropertyService _propertyService;

        public GetByIdProperty(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPut("api/getbyid-owner/{OwnerId}")]
        [SwaggerOperation(
        Summary = "Get by id property in application",
        Description = "Update property",
        OperationId = "property.update",
        Tags = new[] { "PropertyEndpoints" })]
        public override async Task<ActionResult<GetPropertyByIdResponse>> HandleAsync(GetByIdProertyRequest request, CancellationToken cancellationToken = default)
        {
            return await _propertyService.GetPropertyByIdAsync(request, cancellationToken);
        }
    }
}
