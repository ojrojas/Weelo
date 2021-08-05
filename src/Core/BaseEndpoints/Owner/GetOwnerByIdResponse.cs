using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Owner
{
    /// <summary>
    /// Get by id response owner
    /// </summary>
    public class GetOwnerByIdResponse : BaseResponse
    {
        public GetOwnerByIdResponse(Guid correlationId) : base(correlationId) { }
        public GetOwnerByIdResponse() { }
        public OwnerDto OwnerDto { get; set; }
        public string Message { get; set; }
    }
}
