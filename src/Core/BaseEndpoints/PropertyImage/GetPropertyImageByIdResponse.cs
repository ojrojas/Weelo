using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class GetPropertyImageByIdResponse : BaseResponse
    {
        public GetPropertyImageByIdResponse(Guid correlationId) : base(correlationId) { }
        public GetPropertyImageByIdResponse() { }
        public PropertyImageDto PropertyDto { get; set; } = new PropertyImageDto();
        public string Message { get; set; }
    }
}
