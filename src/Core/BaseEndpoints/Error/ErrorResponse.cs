using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Error
{
    public class ErrorResponse : BaseResponse   
    {
        public ErrorResponse(Guid correlationId): base(correlationId) { }
        public ErrorResponse() { }

        public ErrorDto ErrorDto { get; set; }
    }
}
