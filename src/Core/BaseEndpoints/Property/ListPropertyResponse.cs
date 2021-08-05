using System;
using System.Collections.Generic;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    /// <summary>
    /// ListProperty response
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class ListPropertyResponse : BaseResponse
    {
        public ListPropertyResponse(Guid correlationId) : base(correlationId) { }
        public ListPropertyResponse() { }
        public List<PropertyDto> Properties { get; set; } = new List<PropertyDto>();
        public string Message { get; set; }
    }
}
