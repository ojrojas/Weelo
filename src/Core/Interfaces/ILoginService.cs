using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Login;

namespace Weelo.Core.Interfaces
{
    /// <summary>
    /// Login Service Interface
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Login User Application
        /// </summary>
        /// <param name="request">Rquest login </param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<LoginResponse> LoginUserAsync(LoginRequest request, CancellationToken cancellationToken);
    }
}