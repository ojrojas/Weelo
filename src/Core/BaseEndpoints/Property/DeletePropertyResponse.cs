using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    /// <summary>
    /// Delete response 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class DeletePropertyResponse : BaseResponse
    {
        public DeletePropertyResponse(Guid correlationId) : base(correlationId) { }
        public DeletePropertyResponse() { }
        public PropertyDto PropertyDto { get; set; } = new PropertyDto();
        public string Message { get; set; }
    }
}
