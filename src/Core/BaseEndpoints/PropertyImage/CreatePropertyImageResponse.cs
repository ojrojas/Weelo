using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class CreatePropertyImageResponse : BaseResponse  
    {
        public CreatePropertyImageResponse(Guid correlationId): base(correlationId) { }
        public CreatePropertyImageResponse() { }
        public PropertyImageDto PropertyDto { get; set; } = new PropertyImageDto();
    }
}
