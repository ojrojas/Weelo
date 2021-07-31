using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    class GetPropertyTraceByIdResponse : BaseResponse
    {
        public GetPropertyTraceByIdResponse(Guid correlationId) : base(correlationId) { }
        public GetPropertyTraceByIdResponse() { }
        public PropertyDto PropertyDto { get; set; } = new PropertyDto();
        public string Message { get; set; }
    }
}
