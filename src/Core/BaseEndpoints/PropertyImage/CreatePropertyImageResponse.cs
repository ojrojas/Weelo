using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    public class CreatePropertyImageResponse : BaseResponse  
    {
        public CreatePropertyImageResponse(Guid correlationId): base(correlationId) { }
        public CreatePropertyImageResponse() { }
        public PropertyImageDto PropertyImageDto { get; set; } = new PropertyImageDto();
        public string Message { get; set; }
    }
}
