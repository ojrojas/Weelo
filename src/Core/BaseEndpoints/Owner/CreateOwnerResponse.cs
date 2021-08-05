using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Owner
{
    /// <summary>
    /// Create owner response
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class CreateOwnerResponse : BaseResponse
    {
        public CreateOwnerResponse(Guid correlationId): base(correlationId) { }
        public CreateOwnerResponse () { }
        public OwnerDto OwnerDto { get; set; } 
        public string Message { get; set; }
    }
}
