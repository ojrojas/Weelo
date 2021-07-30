using System;
using System.Collections.Generic;
using System.Text;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.User
{
    public class GetUserByIdResponse : BaseResponse
    {
        public GetUserByIdResponse(Guid correlationId) : base(correlationId) { }
        public GetUserByIdResponse() { }
        public UserDto UserDto { get; set; }
        public string Message { get; set; }
    }
}
