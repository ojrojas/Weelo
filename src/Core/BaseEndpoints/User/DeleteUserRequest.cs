using System;

namespace Weelo.Core.BaseEndpoints.User
{
    public class DeleteUserRequest : BaseRequest
    {
        public Guid UserId { get; set; }
    }
}
