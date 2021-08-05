using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyTrace
{
    /// <summary>
    /// Delete property trace response
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class DeletePropertyTraceResponse : BaseResponse
    {
        public DeletePropertyTraceResponse(Guid correlationId) : base(correlationId) { }
        public DeletePropertyTraceResponse() { }
        public PropertyTraceDto PropertyTraceDto { get; set; }
        public string Message { get; set; }
    }
}
