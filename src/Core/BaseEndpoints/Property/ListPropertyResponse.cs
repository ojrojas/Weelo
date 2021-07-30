using System;
using System.Collections.Generic;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class ListPropertyResponse : BaseResponse
    {
        public ListPropertyResponse(Guid correlationId) : base(correlationId) { }
        public ListPropertyResponse() { }
        public List<PropertyDto> PropertyDto { get; set; } = new List<PropertyDto>();
    }
}
