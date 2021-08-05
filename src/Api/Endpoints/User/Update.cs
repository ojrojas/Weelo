using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.User;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.User
{
    [Authorize]
    /// <summary>
    /// Endpoint update user
    /// </summary>
    public class Update : BaseAsyncEndpoint.WithRequest<UpdateUserRequest>.WithResponse<UpdateUserResponse>
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService">User services</param>
        public Update(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Action update user
        /// </summary>
        /// <param name="request">Request users</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Updated user</returns>
        [HttpPut("api/update-user")]
        [SwaggerOperation(
         Summary = "Update user in application",
         Description = "Update user",
         OperationId = "user.update",
         Tags = new[] { "UserEndpoints" })]
        public override async Task<ActionResult<UpdateUserResponse>> HandleAsync(UpdateUserRequest request,
                                                                                 CancellationToken cancellationToken = default)
        {
            return await _userService.UpdateUserAsync(request, cancellationToken);
        }
    }
}
