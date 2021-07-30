using System;
using System.Collections.Generic;
using System.Text;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Owner
{
    public class CreateOwnerResponse : BaseResponse
    {
        public CreateOwnerResponse(Guid correlationId): base(correlationId) { }
        public CreateOwnerResponse () { }
        public OwnerDto OwnerDto { get; set; } 
        public string Message { get; set; }
    }
}
