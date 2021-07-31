using System;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    class GetPropertyImageByIdRequest : BaseRequest
    {
        public Guid PropertyImageId { get; set; }
    }
}
