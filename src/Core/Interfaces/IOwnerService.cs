using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Owner;

namespace Weelo.Core.Interfaces
{
    public interface IOwnerService
    {
        Task<CreateOwnerResponse> CreateOwnerAsync(CreateOwnerRequest request, CancellationToken cancellationToken);
        Task<DeleteOwnerResponse> DeleteOwnerAsync(DeleteOwnerRequest request, CancellationToken cancellationToken);
        Task<GetOwnerByIdResponse> GetOwnerByIdAsync(GetOwnerByIdRequest request, CancellationToken cancellationToken);
        Task<ListOwnerResponse> ListOwnerAsync(CancellationToken cancellationToken);
        Task<UpdateOwnerResponse> UpdateOwnerAsync(UpdateOwnerRequest request, CancellationToken cancellationToken);
    }
}