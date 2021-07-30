using System;

namespace Weelo.Core.BaseEndpoints.Owner
{

    public class DeleteOwnerRequest : BaseRequest
    {
        public Guid OwnerId { get; set; }
    }
}
