using System;
using System.Collections.Generic;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.User
{
    public class ListUserResponse : BaseResponse
    {
        public ListUserResponse(Guid correlationId) : base(correlationId) { }
        public ListUserResponse() { }
        public List<UserDto> Users { get; set; } = new List<UserDto>();
        public string Message { get; set; }
    }
}
