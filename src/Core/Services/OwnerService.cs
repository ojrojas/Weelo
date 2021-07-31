using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Owner;
using Weelo.Core.Dtos;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IAsyncRepository<Owner> _asyncRepository;
        private readonly ILogger<OwnerService> _logger;
        private readonly IMapper _mapper;

        public OwnerService(IAsyncRepository<Owner> asyncRepository, ILogger<OwnerService> logger, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateOwnerResponse> CreateOwnerAsync(CreateOwnerRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateOwnerResponse(request.CorrelationId);
            _logger.LogInformation($"Create Owner Request - {request.CorrelationId}");
            var owner = _mapper.Map<Owner>(request);
            var result = await _asyncRepository.AddAsync(owner, cancellationToken);
            if (result == null)
                response.Message = "Error to create owner";

            response.OwnerDto = _mapper.Map<OwnerDto>(result);
            return response;
        }

        public async Task<UpdateOwnerResponse> UpdateOwnerAsync(UpdateOwnerRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateOwnerResponse(request.CorrelationId);
            _logger.LogInformation($"Update Owner Request - {request.CorrelationId}");
            var ownerToUpdate = await _asyncRepository.GetByIdAsync(request.OwnerId, cancellationToken);

            ownerToUpdate.UpdateProperties(
                name: request.OwnerDto.Name,
                address: request.OwnerDto.Address,
                photo: request.OwnerDto.Photo,
                birthday: request.OwnerDto.Birthday,
                modifiedBy: request.OwnerDto.ModifiedBy,
                state: request.OwnerDto.State);

            var result = await _asyncRepository.UpdateAsync(ownerToUpdate, cancellationToken);
            if (result == null)
                response.Message = "Error to update owner";

            response.OwnerDto = _mapper.Map<OwnerDto>(result);
            return response;
        }

        public async Task<DeleteOwnerResponse> DeleteOwnerAsync(DeleteOwnerRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteOwnerResponse(request.CorrelationId);
            _logger.LogInformation($"Delete Owner Request - {request.CorrelationId}");
            var ownerToDelete = await _asyncRepository.GetByIdAsync(request.OwnerId, cancellationToken);

            var result = await _asyncRepository.DeleteAsync(ownerToDelete, cancellationToken);
            if (result == null)
                response.Message = "Error to delete owner";

            response.OwnerDto = _mapper.Map<OwnerDto>(result);
            return response;
        }

        public async Task<GetOwnerByIdResponse> GetOwnerByIdAsync(GetOwnerByIdRequest request, CancellationToken cancellationToken)
        {
            var response = new GetOwnerByIdResponse(request.CorrelationId);
            _logger.LogInformation($"Get Owner By Id Request - {request.CorrelationId}");
            var result = await _asyncRepository.GetByIdAsync(request.OwnerId, cancellationToken);
            if (result == null)
                response.Message = "Error to get owner";

            response.OwnerDto = _mapper.Map<OwnerDto>(result);
            return response;
        }

        public async Task<ListOwnerResponse> ListOwnerAsync(CancellationToken cancellationToken)
        {
            var response = new ListOwnerResponse();
            _logger.LogInformation($"List Owners Request - Get");
            var result = await _asyncRepository.ListAllAsync(cancellationToken);
            if (result == null)
                response.Message = "Error to get owner";
            if (result.Any())
                response.Owners.AddRange(result.Select(_mapper.Map<OwnerDto>));

            return response;
        }
    }
}
