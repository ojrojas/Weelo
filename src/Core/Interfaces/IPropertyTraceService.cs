using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyTrace;

namespace Weelo.Core.Interfaces
{
    public interface IPropertyTraceService
    {
        Task<CreatePropertyTraceResponse> CreatePropertyTraceAsync(CreatePropertyTraceRequest request, CancellationToken cancellationToken);
        Task<DeletePropertyTraceResponse> DeletePropertyTraceAsync(DeletePropertyTraceRequest request, CancellationToken cancellationToken);
        Task<GetByIdPropertyTraceResponse> GetByIdPropertyTraceAsync(GetByIdPropertyTraceRequest request, CancellationToken cancellationToken);
        Task<ListPropertyTraceResponse> ListPropertyTraceAsync(CancellationToken cancellationToken);
        Task<UpdatePropertyTraceResponse> UpdatePropertyTraceAsync(UpdatePropertyTraceRequest request, CancellationToken cancellationToken);
    }
}