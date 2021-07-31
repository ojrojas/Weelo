using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.User;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.User
{
    public class List : BaseAsyncEndpoint.WithoutRequest.WithResponse<ListUserResponse>
    {
        private readonly IUserService _userService;

        public List(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("api/list-user")]
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
