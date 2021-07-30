using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.User;

namespace Weelo.Core.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken);
        Task<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest request, CancellationToken cancellationToken);
        Task<GetUserByIdResponse> GetUserByIdAsync(GetUserByIdResquest request, CancellationToken cancellationToken);
        Task<ListUserResponse> ListUserAsync(CancellationToken cancellationToken);
        Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken);
    }
}