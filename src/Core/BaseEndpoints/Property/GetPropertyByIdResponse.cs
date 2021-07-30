using System;
using System.Collections.Generic;
using System.Text;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    class GetPropertyByIdResponse : BaseResponse
    {
        public GetPropertyByIdResponse(Guid correlationId) : base(correlationId) { }
        public GetPropertyByIdResponse() { }
        public PropertyDto PropertyDto { get; set; } = new PropertyDto();
    }
}
