using System;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    public class DeletePropertyImageRequest: BaseRequest
    {
        public Guid PropertyImageId { get; set; }
    }
}
