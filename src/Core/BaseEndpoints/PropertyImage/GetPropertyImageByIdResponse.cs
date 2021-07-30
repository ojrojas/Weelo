using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    class GetPropertyImageByIdResponse : BaseResponse
    {
        public GetPropertyImageByIdResponse(Guid correlationId) : base(correlationId) { }
        public GetPropertyImageByIdResponse() { }
        public PropertyImageDto PropertyDto { get; set; } = new PropertyImageDto();
    }
}
