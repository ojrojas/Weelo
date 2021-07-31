using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class DeletePropertyImageResponse : BaseResponse
    {
        public DeletePropertyImageResponse(Guid correlationId) : base(correlationId) { }
        public DeletePropertyImageResponse() { }
        public PropertyImageDto PropertyImageDto { get; set; } = new PropertyImageDto();
        public string Message { get; set; }
    }
}
