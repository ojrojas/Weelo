using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;

namespace Weelo.Core.Interfaces
{
    public interface IPropertyService
    {
        Task<CreatePropertyResponse> CreatePropertyAsync(CreatePropertyRequest request, CancellationToken cancellationToken);
        Task<DeletePropertyResponse> DeletePropertyAsync(DeletePropertyRequest request, CancellationToken cancellationToken);
        Task<GetPropertyByIdResponse> GetPropertyByIdAsync(GetByIdProertyImageRequest request, CancellationToken cancellationToken);
        Task<ListPropertyResponse> ListPropertyAsync(CancellationToken cancellationToken);
        Task<UpdatePropertyResponse> UpdatePropertyAsync(UpdatePropertyRequest request, CancellationToken cancellationToken);
    }
}