using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.User;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.User
{
    /// <summary>
    /// Endpoint create user
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>03/08/2021</date>
    public class Create : BaseAsyncEndpoint.WithRequest<CreateUserRequest>.WithResponse<CreateUserResponse>
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService">User services</param>
        public Create(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Action create users
        /// </summary>
        /// <param name="request">request user</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>User Created</returns>
        [HttpPost("api/create-user")]
        [SwaggerOperation(
          Summary = "Create user in application",
          Description = "Create user",
          OperationId = "user.create",
          Tags = new[] { "UserEndpoints" })]
        public override async Task<ActionResult<CreateUserResponse>> HandleAsync(CreateUserRequest request,
                                                                                 CancellationToken cancellationToken = default)
        {
            return await _userService.CreateUserAsync(request, cancellationToken);
        }
    }
}
