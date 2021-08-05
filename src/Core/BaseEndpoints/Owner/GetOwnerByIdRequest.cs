using System;

namespace Weelo.Core.BaseEndpoints.Owner
{
    /// <summary>
    /// Get owner by id request
    /// </summary>
    public class GetOwnerByIdRequest : BaseRequest
    {
        public Guid OwnerId { get; set; }
    }
}
