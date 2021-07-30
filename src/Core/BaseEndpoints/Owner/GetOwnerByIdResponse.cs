using System;
using System.Collections.Generic;
using System.Text;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Owner
{
    public class GetOwnerByIdResponse : BaseResponse
    {
        public GetOwnerByIdResponse(Guid correlationId) : base(correlationId) { }
        public GetOwnerByIdResponse() { }
        public OwnerDto OwnerDto { get; set; }
        public string Message { get; set; }
    }
}
