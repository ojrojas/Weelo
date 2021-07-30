using System;
using System.Collections.Generic;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class ListPropertyTraceResponse : BaseResponse
    {
        public ListPropertyTraceResponse(Guid correlationId) : base(correlationId) { }
        public ListPropertyTraceResponse() { }
        public List<PropertyDto> PropertyDto { get; set; } = new List<PropertyDto>();
    }
}
