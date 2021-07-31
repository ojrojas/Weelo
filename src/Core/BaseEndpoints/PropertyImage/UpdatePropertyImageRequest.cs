using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    public class UpdatePropertyImageRequest : BaseRequest
    {
        public Guid PropertyImageId { get; set; }
        public PropertyImageDto PropertyImageDto { get; set; }
    }
}
