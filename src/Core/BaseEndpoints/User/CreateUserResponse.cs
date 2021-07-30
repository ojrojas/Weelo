using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.User
{
    public class CreateUserResponse : BaseResponse
    {
        public CreateUserResponse(Guid correlationId) : base(correlationId) { }
        public CreateUserResponse() { }
        public UserDto UserDto { get; set; }
        public string Message { get; set; }
    }
}
