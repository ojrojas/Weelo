using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    public class GetByIdPropertyImageResponse : BaseResponse
    {
        public GetByIdPropertyImageResponse(Guid correlationId) : base(correlationId) { }
        public GetByIdPropertyImageResponse() { }
        public PropertyImageDto PropertyImageDto { get; set; } = new PropertyImageDto();
        public string Message { get; set; }
    }
}
