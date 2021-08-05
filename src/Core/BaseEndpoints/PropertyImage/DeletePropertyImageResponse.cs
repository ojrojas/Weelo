using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    /// <summary>
    /// Delete property image response
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class DeletePropertyImageResponse : BaseResponse
    {
        public DeletePropertyImageResponse(Guid correlationId) : base(correlationId) { }
        public DeletePropertyImageResponse() { }
        public PropertyImageDto PropertyImageDto { get; set; } = new PropertyImageDto();
        public string Message { get; set; }
    }
}
