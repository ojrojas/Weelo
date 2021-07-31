using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.User;
using Weelo.Core.Interfaces;

namespace Weelo.Api.Endpoints.User
{
    public class Create : BaseAsyncEndpoint.WithRequest<CreateUserRequest>.WithResponse<CreateUserResponse>
    {
        private readonly IUserService _userService;

        public Create(IUserService userService)
        {
            _userService = userService;
        }


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
