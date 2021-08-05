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
    /// Endpoint getbyid user
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>02/08/2021</date>
    public class GetUserById : BaseAsyncEndpoint.WithRequest<GetUserByIdResquest>.WithResponse<GetUserByIdResponse>
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="userService">User Service</param>
        public GetUserById(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Action get by id user
        /// </summary>
        /// <param name="request">Request user</param>
        /// <param name="cancellationToken">Cancellationtoken</param>
        /// <returns>User requested</returns>
        [HttpGet("api/getbyid-user/{UserId}")]
        [SwaggerOperation(
         Summary = "Get user by id in application",
         Description = "Get by id user",
         OperationId = "user.getbyid",
         Tags = new[] { "UserEndpoints" })]
        public override async Task<ActionResult<GetUserByIdResponse>> HandleAsync([FromRoute]GetUserByIdResquest request, CancellationToken cancellationToken = default)
        {
            return await _userService.GetUserByIdAsync(request, cancellationToken);
        }
    }
}
