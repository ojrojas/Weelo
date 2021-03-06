using System;
using System.Collections.Generic;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    /// <summary>
    /// List property response image
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class ListPropertyImageResponse : BaseResponse
    {
        public ListPropertyImageResponse(Guid correlationId) : base(correlationId) { }
        public ListPropertyImageResponse() { }
        public List<PropertyImageDto> PropertiesImage { get; set; } = new List<PropertyImageDto>();
        public string Message { get; set; }
    }
}
