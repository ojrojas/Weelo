using System;
using System.Collections.Generic;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class ListPropertyImageResponse : BaseResponse
    {
        public ListPropertyImageResponse(Guid correlationId) : base(correlationId) { }
        public ListPropertyImageResponse() { }
        public List<PropertyImageDto> PropertyDto { get; set; } = new List<PropertyImageDto>();
    }
}
