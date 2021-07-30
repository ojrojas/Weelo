using System;
using System.Collections.Generic;
using System.Text;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Owner
{
    public class ListOwnerResponse : BaseResponse
    {
        public ListOwnerResponse(Guid correlationId) : base(correlationId) { }
        public ListOwnerResponse() { }
        public List<OwnerDto> Owners { get; set; } = new List<OwnerDto>();
    }
}
