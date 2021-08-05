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
    /// Endpoint listed users
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>02/08/2021</date>
    public class List : BaseAsyncEndpoint.WithoutRequest.WithResponse<ListUserResponse>
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService">User Service</param>
        public List(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Action listed users
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>user listed</returns>
        [HttpGet("api/list-users")]
        [SwaggerOperation(
         Summary = "List users in application",
         Description = "List users",
         OperationId = "user.list",
         Tags = new[] { "UserEndpoints" })]
        public override async Task<ActionResult<ListUserResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _userService.ListUserAsync(cancellationToken);
        }
    }
}
