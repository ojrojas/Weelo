using System;

namespace Weelo.Core.BaseEndpoints.Owner
{
    public class GetOwnerByIdRequest : BaseRequest
    {
        public Guid OwnerId { get; set; }
    }
}
