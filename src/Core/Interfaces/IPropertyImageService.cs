using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;
using Weelo.Core.BaseEndpoints.PropertyImage;

namespace Weelo.Core.Interfaces
{
    public interface IPropertyImageService
    {
        Task<CreatePropertyImageResponse> CreatePropertyImageAsync(CreatePropertyRequest request, CancellationToken cancellationToken);
        Task<DeletePropertyImageResponse> DeletePropertyAsync(DeletePropertyImageRequest request, CancellationToken cancellationToken);
        Task<GetPropertyImageByIdResponse> GetPropertyImageByIdAsync(GetByIdProertyImageRequest request, CancellationToken cancellationToken);
        Task<ListPropertyImageResponse> ListPropertyImageAsync(CancellationToken cancellationToken);
        Task<UpdatePropertyImageResponse> UpdatePropertyImageAsync(UpdatePropertyImageRequest request, CancellationToken cancellationToken);
    }
}