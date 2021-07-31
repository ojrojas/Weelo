using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class UpdatePropertyImageResponse: BaseResponse
    {
        public UpdatePropertyImageResponse(Guid correlationId) : base(correlationId) { }
        public UpdatePropertyImageResponse() { }
        public PropertyImageDto PropertyDto { get; set; } = new PropertyImageDto();
        public string Message { get; set; }
    }
}
