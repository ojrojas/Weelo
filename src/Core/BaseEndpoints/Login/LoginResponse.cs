using System;

namespace Weelo.Core.BaseEndpoints.Login
{
    /// <summary>
    /// Login response
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/08/2021</date>
    public class LoginResponse : BaseResponse
    {
        public LoginResponse(Guid correlationId) : base(correlationId) { }
        public LoginResponse() { }
        public string Auth_Token { get; set; }
        public string Message { get; set; }

    }
}
