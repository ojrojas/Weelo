using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.User
{
    public class UpdateUserRequest : BaseRequest
    {
        public Guid UserId { get; set; }
        public UserDto UserDto { get; set; }
    }
}
