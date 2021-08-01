using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;
using Weelo.Core.BaseEndpoints.PropertyImage;

namespace Weelo.Core.Interfaces
{
    public interface IPropertyImageService
    {
        Task<CreatePropertyImageResponse> CreatePropertyImageAsync(CreatePropertyImageRequest request, CancellationToken cancellationToken);
        Task<DeletePropertyImageResponse> DeletePropertyImageAsync(DeletePropertyImageRequest request, CancellationToken cancellationToken);
        Task<GetByIdPropertyImageResponse> GetPropertyImageByIdAsync(GetByIdProertyImageRequest request, CancellationToken cancellationToken);
        Task<ListPropertyImageResponse> ListPropertyImageAsync(CancellationToken cancellationToken);
        Task<UpdatePropertyImageResponse> UpdatePropertyImageAsync(UpdatePropertyImageRequest request, CancellationToken cancellationToken);
    }
}