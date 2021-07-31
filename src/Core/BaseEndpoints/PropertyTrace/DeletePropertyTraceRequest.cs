using System;

namespace Weelo.Core.BaseEndpoints.PropertyTrace
{
    public class DeletePropertyTraceRequest: BaseRequest
    {
        public Guid PropertyTraceId { get; set; }
    }
}
