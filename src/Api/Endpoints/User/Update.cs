using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.User;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.User
{
    public class Update : BaseAsyncEndpoint.WithRequest<UpdateUserRequest>.WithResponse<UpdateUserResponse>
    {
        private readonly IUserService _userService;

        public Update(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("api/update-user/{UserId}")]
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
