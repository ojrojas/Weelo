using System;
using System.Collections.Generic;
using System.Text;

namespace Weelo.Core.BaseEndpoints.Login
{
    public class LoginResponse : BaseResponse
    {
        public LoginResponse(Guid correlationId) : base(correlationId) { }
        public LoginResponse() { }
        public string Auth_Token { get; set; }
        public string Message { get; set; }

    }
}
