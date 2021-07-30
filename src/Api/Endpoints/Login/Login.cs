using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Login;
using Weelo.Core.Interfaces;

namespace Api.Endpoints.Login
{
    public class Login : BaseAsyncEndpoint.WithRequest<LoginRequest>.WithResponse<LoginResponse>
    {
        private readonly ILoginService _loginService;

        public Login(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("api/login")]
        [SwaggerOperation(
          Summary = "login user in application",
          Description = "Login user",
          OperationId = "login.login",
          Tags = new[] { "LoginEndpoinst" })]
        public override async Task<ActionResult<LoginResponse>> HandleAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            return await _loginService.LoginUser(request, cancellationToken);
        }
    }
}
