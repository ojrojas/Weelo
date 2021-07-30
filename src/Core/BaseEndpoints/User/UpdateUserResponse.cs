using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.User
{
    public class UpdateUserResponse : BaseResponse
    {
        public UpdateUserResponse(Guid correlationId) : base(correlationId) { }
        public UpdateUserResponse() { }
        public UserDto UserDto { get; set; }
        public string Message { get; set; }
    }
}
