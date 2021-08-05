using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    /// <summary>
    /// Get property by id response
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class GetPropertyByIdResponse : BaseResponse
    {
        public GetPropertyByIdResponse(Guid correlationId) : base(correlationId) { }
        public GetPropertyByIdResponse() { }
        public PropertyDto PropertyDto { get; set; } = new PropertyDto();
        public string Message { get; set; }
    }
}
