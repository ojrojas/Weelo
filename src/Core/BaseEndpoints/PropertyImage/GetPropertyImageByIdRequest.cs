using System;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    /// <summary>
    /// Get by id property image request
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class GetByIdProertyImageRequest : BaseRequest
    {
        public Guid PropertyImageId { get; set; }
    }
}
