using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Login;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;
using Weelo.Core.Specifications;

namespace Weelo.Core.Services
{
    public class LoginService : ILoginService
    {
        private readonly IAsyncRepository<User> _asyncRepository;
        private readonly ILogger<UserService> _logger;
        private readonly ITokenClaims _tokenClaims;

        public LoginService(IAsyncRepository<User> asyncRepository, ILogger<UserService> logger, IMapper mapper, ITokenClaims tokenClaims)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _tokenClaims = tokenClaims;
        }

        public async Task<LoginResponse> LoginUser(LoginRequest request, CancellationToken cancellationToken)
        {
            var response = new LoginResponse(request.CorrelationId);
            _logger.LogInformation($"Login User Request - {request.CorrelationId}");
            var spec = new LoginSpecification(request.UserName, request.Password);

            var result = await _asyncRepository.FirstOrDefaultAsync(spec, cancellationToken);
            if (result == null)
                response.Message = "login user invalid!";

            response.Auth_Token = result != null ? await _tokenClaims.GetTokenAsync(result) : string.Empty;
            return response;
        }
    }
}
