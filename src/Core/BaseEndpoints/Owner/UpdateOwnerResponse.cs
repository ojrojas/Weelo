using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Owner
{
    public class UpdateOwnerResponse : BaseResponse
    {
        public UpdateOwnerResponse(Guid correlationId) : base(correlationId) { }
        public UpdateOwnerResponse() { }
        public OwnerDto OwnerDto { get; set; }
        public string Message { get; set; }
    }
}
