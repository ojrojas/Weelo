using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    public class UpdatePropertyImageResponse: BaseResponse
    {
        public UpdatePropertyImageResponse(Guid correlationId) : base(correlationId) { }
        public UpdatePropertyImageResponse() { }
        public PropertyImageDto PropertyImageDto { get; set; } = new PropertyImageDto();
        public string Message { get; set; }
    }
}
