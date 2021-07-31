using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Login;

namespace Weelo.Core.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginUserAsync(LoginRequest request, CancellationToken cancellationToken);
    }
}