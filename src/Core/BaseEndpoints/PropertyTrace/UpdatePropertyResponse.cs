using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyTrace
{
    /// <summary>
    /// Update property trace response
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class UpdatePropertyTraceResponse : BaseResponse
    {
        public UpdatePropertyTraceResponse(Guid correlationId) : base(correlationId) { }
        public UpdatePropertyTraceResponse() { }
        public PropertyTraceDto PropertyTraceDto { get; set; }
        public string Message { get; set; }
    }
}
