using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.User;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.User
{
    public class Delete : BaseAsyncEndpoint.WithRequest<DeleteUserRequest>.WithResponse<DeleteUserResponse>
    {
        private readonly IUserService _userService;

        public Delete(IUserService userService)
        {
            _userService = userService;
        }

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
