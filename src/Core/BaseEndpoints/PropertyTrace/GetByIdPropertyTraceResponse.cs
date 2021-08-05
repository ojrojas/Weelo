using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyTrace
{
    /// <summary>
    /// Get by id property trace response
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class GetByIdPropertyTraceResponse : BaseResponse
    {
        public GetByIdPropertyTraceResponse(Guid correlationId) : base(correlationId) { }
        public GetByIdPropertyTraceResponse() { }
        public PropertyTraceDto PropertyTraceDto { get; set; }
        public string Message { get; set; }
    }
}
