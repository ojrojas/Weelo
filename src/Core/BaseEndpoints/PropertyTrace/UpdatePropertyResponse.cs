using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class UpdatePropertyTraceResponse : BaseResponse
    {
        public UpdatePropertyTraceResponse(Guid correlationId) : base(correlationId) { }
        public UpdatePropertyTraceResponse() { }
        public PropertyDto PropertyDto { get; set; } = new PropertyDto();
        public string Message { get; set; }
    }
}
