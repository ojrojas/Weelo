﻿namespace Weelo.Core.BaseEndpoints.Login
{
    public class LoginRequest: BaseRequest
    {
        public string UserName { get; set; }
        public string  Password { get; set; }
    }
}
