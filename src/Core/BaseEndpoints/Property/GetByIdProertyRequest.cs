using System;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class GetByIdProertyRequest: BaseRequest
    {
        public Guid PropertyId { get; set; }
    }
}
