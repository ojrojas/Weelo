using System;

namespace Weelo.Core.BaseEndpoints.PropertyTrace
{
    public class GetPropertyTraceByIdRequest: BaseRequest
    {
        public Guid PropertyTraceId { get; set; }
    }
}
