using System;

namespace Weelo.Core.BaseEndpoints.User
{
    public class GetUserByIdResquest: BaseRequest
    {
        public Guid UserId { get; set; }
    }
}
