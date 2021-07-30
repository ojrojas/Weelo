using System;
using System.Collections.Generic;
using System.Text;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    class GetPropertyTraceByIdResponse : BaseResponse
    {
        public GetPropertyTraceByIdResponse(Guid correlationId) : base(correlationId) { }
        public GetPropertyTraceByIdResponse() { }
        public PropertyDto PropertyDto { get; set; } = new PropertyDto();
    }
}
