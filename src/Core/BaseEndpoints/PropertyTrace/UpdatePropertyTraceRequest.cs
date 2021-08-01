using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyTrace
{
    public class UpdatePropertyTraceRequest: BaseRequest
    {
        public Guid PropertyTraceId { get; set; }
        public PropertyTraceDto PropertyTraceDto { get; set; }
    }
}
