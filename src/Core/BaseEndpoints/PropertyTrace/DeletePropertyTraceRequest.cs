using System;

namespace Weelo.Core.BaseEndpoints.PropertyTrace
{
    /// <summary>
    /// Delete property trace request
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class DeletePropertyTraceRequest: BaseRequest
    {
        public Guid PropertyTraceId { get; set; }
    }
}
