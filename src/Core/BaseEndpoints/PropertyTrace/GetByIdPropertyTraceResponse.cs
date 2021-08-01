using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyTrace
{
    public class GetByIdPropertyTraceResponse : BaseResponse
    {
        public GetByIdPropertyTraceResponse(Guid correlationId) : base(correlationId) { }
        public GetByIdPropertyTraceResponse() { }
        public PropertyTraceDto PropertyTraceDto { get; set; }
        public string Message { get; set; }
    }
}
