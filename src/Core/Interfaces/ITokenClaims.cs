using System.Threading.Tasks;
using Weelo.Core.Entities;

namespace Weelo.Core.Interfaces
{
    public interface ITokenClaims
    {
        Task<string> GetTokenAsync(User user);
    }
}