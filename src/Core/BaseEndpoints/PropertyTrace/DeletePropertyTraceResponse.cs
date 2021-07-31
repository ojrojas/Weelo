using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class DeletePropertyTraceResponse : BaseResponse
    {
        public DeletePropertyTraceResponse(Guid correlationId) : base(correlationId) { }
        public DeletePropertyTraceResponse() { }
        public PropertyDto PropertyDto { get; set; } = new PropertyDto();
        public string Message { get; set; }
    }
}
