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
    /// Endpoint delete user
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>03/08/2021</date>
    public class Delete : BaseAsyncEndpoint.WithRequest<DeleteUserRequest>.WithResponse<DeleteUserResponse>
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService">Service user</param>
        public Delete(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Action delete user
        /// </summary>
        /// <param name="request">Requested delete user</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Deleted user</returns>
        [HttpDelete("api/delete-user/{UserId}")]
        [SwaggerOperation(
         Summary = "Delete user in application",
         Description = "Delete user",
         OperationId = "user.delete",
         Tags = new[] { "UserEndpoints" })]
        public override async Task<ActionResult<DeleteUserResponse>> HandleAsync([FromRoute]DeleteUserRequest request,
                                                                                 CancellationToken cancellationToken = default)
        {
            return await _userService.DeleteUserAsync(request, cancellationToken);
        }
    }
}
