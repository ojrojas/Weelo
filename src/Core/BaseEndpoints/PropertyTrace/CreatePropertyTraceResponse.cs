using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyTrace
{
    /// <summary>
    /// Create  property trace response
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class CreatePropertyTraceResponse : BaseResponse  
    {
        public CreatePropertyTraceResponse(Guid correlationId): base(correlationId) { }
        public CreatePropertyTraceResponse() { }
        public PropertyTraceDto PropertyDto { get; set; } = new PropertyTraceDto();
        public string Message { get; set; }
    }
}
