using System;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class GetByIdProertyImageRequest: BaseRequest
    {
        public Guid PropertyId { get; set; }
    }
}
