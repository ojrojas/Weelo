using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    /// <summary>
    /// Create Property
    /// </summary>
    /// <author>OScar Julian Rojas</author>
    public class CreatePropertyResponse : BaseResponse  
    {
        public CreatePropertyResponse (Guid correlationId): base(correlationId) { }
        public CreatePropertyResponse() { }
        public PropertyDto PropertyDto { get; set; } = new PropertyDto();
        public string Message{ get; set; }
    }
}
