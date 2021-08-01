using System;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    public class GetByIdProertyImageRequest : BaseRequest
    {
        public Guid PropertyImageId { get; set; }
    }
}
