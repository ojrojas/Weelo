using System;

namespace Weelo.Core.BaseEndpoints.Owner
{
    /// <summary>
    /// Delete request owner
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/08/2021</date>
    public class DeleteOwnerRequest : BaseRequest
    {
        public Guid OwnerId { get; set; }
    }
}
