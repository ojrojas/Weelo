using System;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    /// <summary>
    /// Delete property image request
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>02/08/2021</date>
    public class DeletePropertyImageRequest: BaseRequest
    {
        public Guid PropertyImageId { get; set; }
    }
}
