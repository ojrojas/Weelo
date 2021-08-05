using System;
using System.Collections.Generic;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyTrace
{
    /// <summary>
    /// List  property traceresponse
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class ListPropertyTraceResponse : BaseResponse
    {
        public ListPropertyTraceResponse(Guid correlationId) : base(correlationId) { }
        public ListPropertyTraceResponse() { }
        public List<PropertyTraceDto> PropertiesTrace { get; set; } = new List<PropertyTraceDto>();
        public string Message { get; set; }
    }
}
