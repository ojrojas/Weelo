using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    /// <summary>
    /// Create property image response
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>02/08/2021</date>
    public class CreatePropertyImageResponse : BaseResponse  
    {
        public CreatePropertyImageResponse(Guid correlationId): base(correlationId) { }
        public CreatePropertyImageResponse() { }
        public PropertyImageDto PropertyImageDto { get; set; } = new PropertyImageDto();
        public string Message { get; set; }
    }
}
