using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.User;
using Weelo.Core.Interfaces;

namespace Api.Endpoints.User
{
    public class GetUserById : BaseAsyncEndpoint.WithRequest<GetUserByIdResquest>.WithResponse<GetUserByIdResponse>
    {
        private readonly IUserService _userService;

        public GetUserById(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("api/getbyid-user/{UserId}")]
        [SwaggerOperation(
         Summary = "Get user by id in application",
         Description = "Get by id user",
         OperationId = "user.getbyid",
         Tags = new[] { "UserEndpoints" })]
        public override async Task<ActionResult<GetUserByIdResponse>> HandleAsync(GetUserByIdResquest request, CancellationToken cancellationToken = default)
        {
            return await _userService.GetUserByIdAsync(request, cancellationToken);
        }
    }
}
