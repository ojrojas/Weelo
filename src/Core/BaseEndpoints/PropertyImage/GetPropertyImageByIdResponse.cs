using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    /// <summary>
    /// Get by id response property image
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class GetByIdPropertyImageResponse : BaseResponse
    {
        public GetByIdPropertyImageResponse(Guid correlationId) : base(correlationId) { }
        public GetByIdPropertyImageResponse() { }
        public PropertyImageDto PropertyImageDto { get; set; } = new PropertyImageDto();
        public string Message { get; set; }
    }
}
