using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class DeletePropertyResponse : BaseResponse
    {
        public DeletePropertyResponse(Guid correlationId) : base(correlationId) { }
        public DeletePropertyResponse() { }
        public PropertyDto PropertyDto { get; set; } = new PropertyDto();
        public string Message { get; set; }
    }
}
