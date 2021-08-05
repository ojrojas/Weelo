using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Owner
{
    /// <summary>
    /// Update owner response
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/08/2021</date>
    public class UpdateOwnerResponse : BaseResponse
    {
        public UpdateOwnerResponse(Guid correlationId) : base(correlationId) { }
        public UpdateOwnerResponse() { }
        public OwnerDto OwnerDto { get; set; }
        public string Message { get; set; }
    }
}
