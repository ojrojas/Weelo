using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Owner
{
    public class UpdateOwnerRequest : BaseRequest
    {
        public Guid OwnerId { get; protected set; }
        public OwnerDto OwnerDto { get; set; }
    }
}
