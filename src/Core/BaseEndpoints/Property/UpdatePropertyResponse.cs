using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    /// <summary>
    /// Update property response
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class UpdatePropertyResponse: BaseResponse
    {
        public UpdatePropertyResponse(Guid correlationId) : base(correlationId) { }
        public UpdatePropertyResponse() { }
        public PropertyDto PropertyDto { get; set; } = new PropertyDto();
        public string Message { get; set; }
    }
}
