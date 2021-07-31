using System;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class DeletePropertyRequest : BaseRequest
    {
        public Guid PropertyId { get; set; }
    }
}
