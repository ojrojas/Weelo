using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Login;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;
using Weelo.Core.Specifications;

namespace Weelo.Core.Services
{
    /// <summary>
    /// Login service
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/08/2021</date>
    public class LoginService : ILoginService
    {
        private readonly IAsyncRepository<User> _asyncRepository;
        private readonly ILogger<LoginService> _logger;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Construnctor Login services
        /// </summary>
        /// <param name="asyncRepository">repository generric</param>
        /// <param name="logger">logger application</param>
        /// <param name="tokenClaims">service Token claim</param>
        public LoginService(IAsyncRepository<User> asyncRepository, ILogger<LoginService> logger, ITokenClaims tokenClaims)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Login User Application
        /// </summary>
        /// <param name="request">Rquest login </param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Login Response</returns>
        public async Task<LoginResponse> LoginUserAsync(LoginRequest request, CancellationToken cancellationToken)
        {
            var response = new LoginResponse(request.CorrelationId());
            _logger.LogInformation($"Login User Request - {request.CorrelationId()}");
            var spec = new LoginSpecification(request.UserName, request.Password);

            var result = await _asyncRepository.FirstOrDefaultAsync(spec, cancellationToken);
            if (result == null)
                response.Message = "login user invalid!";

            response.Auth_Token = result != null ? await _tokenClaims.GetTokenAsync(result) : string.Empty;
            return response;
        }
    }
}
