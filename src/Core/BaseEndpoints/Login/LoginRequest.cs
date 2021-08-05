namespace Weelo.Core.BaseEndpoints.Login
{
    /// <summary>
    /// Login request 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/08/2021</date>
    public class LoginRequest: BaseRequest
    {
        public string UserName { get; set; }
        public string  Password { get; set; }
    }
}
