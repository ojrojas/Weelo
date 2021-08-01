using System;

namespace Weelo.Core.BaseEndpoints.PropertyTrace
{
    public class GetByIdPropertyTraceRequest : BaseRequest
    {
        public Guid PropertyTraceId { get; set; }
    }
}
