using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Login;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.Login
{
    /// <summary>
    /// Endpoint loggin application
    /// </summary>
    /// <auhtor>Oscar Julian Rojas</auhtor>
    /// <date>2/08/2021</date>
    public class Login : BaseAsyncEndpoint.WithRequest<LoginRequest>.WithResponse<LoginResponse>
    {
        private readonly ILoginService _loginService;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="loginService">service login</param>
        public Login(ILoginService loginService)
        {
            _loginService = loginService;
        }


        /// <summary>
        /// Login action
        /// </summary>
        /// <param name="request">request application</param>
        /// <param name="cancellationToken">cancellation token on fail request</param>
        /// <returns>Token jwt</returns>
        [HttpPost("api/login")]
        [SwaggerOperation(
          Summary = "login user in application",
          Description = "Login user",
          OperationId = "login.login",
          Tags = new[] { "LoginEndpoinst" })]
        public override async Task<ActionResult<LoginResponse>> HandleAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            return await _loginService.LoginUserAsync(request, cancellationToken);
        }
    }
}
