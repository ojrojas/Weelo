using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.User
{
    public class DeleteUserResponse: BaseResponse
    {
        public DeleteUserResponse(Guid correlationId) : base(correlationId) { }
        public DeleteUserResponse() { }
        public UserDto UserDto { get; set; }
        public string Message { get; set; }
    }
}
