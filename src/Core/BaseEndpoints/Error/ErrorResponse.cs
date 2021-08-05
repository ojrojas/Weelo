using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Error
{
    /// <summary>
    /// Error response Dto middleware respose
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class ErrorResponse : BaseResponse   
    {
        public ErrorResponse(Guid correlationId): base(correlationId) { }
        public ErrorResponse() { }

        public ErrorDto ErrorDto { get; set; }
    }
}
