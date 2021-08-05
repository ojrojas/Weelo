using System;

namespace Weelo.Core.BaseEndpoints.PropertyTrace
{
    /// <summary>
    /// Get by id property trace request
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class GetByIdPropertyTraceRequest : BaseRequest
    {
        public Guid PropertyTraceId { get; set; }
    }
}
