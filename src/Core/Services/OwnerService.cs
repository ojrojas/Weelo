using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Owner;
using Weelo.Core.Dtos;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Services
{
    /// <summary>
    /// Owner service
    /// </summary>
    /// <author>Osscar Julian Rojas</author>
    /// <date>29/08/2021</date>
    public class OwnerService : IOwnerService
    {
        private readonly IAsyncRepository<Owner> _asyncRepository;
        private readonly ILogger<OwnerService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="asyncRepository">Service repostiry</param>
        /// <param name="logger">logger application</param>
        /// <param name="mapper">mapper entities</param>
        public OwnerService(IAsyncRepository<Owner> asyncRepository,
                            ILogger<OwnerService> logger,
                            IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Create Owner
        /// </summary>
        /// <param name="request">Owner to created</param>
        /// <param name="cancellationToken">Cancellation event</param>
        /// <returns>Created Owner</returns>
        public async Task<CreateOwnerResponse> CreateOwnerAsync(CreateOwnerRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateOwnerResponse(request.CorrelationId());
            _logger.LogInformation($"Create Owner Request - {request.CorrelationId()}");
            var owner = new Owner
            {
                Name = request.Name,
                Address = request.Address,
                Birthday = request.Birthday,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.Now,
                Photo = request.Photo,
                State = true
            };

            var result = await _asyncRepository.AddAsync(owner, cancellationToken);
            if (result == null)
                response.Message = "Error to create owner";

            response.OwnerDto = _mapper.Map<OwnerDto>(result);
            return response;
        }

        /// <summary>
        /// /Update owner 
        /// </summary>
        /// <param name="request">request update </param>
        /// <param name="cancellationToken">cancellation event</param>
        /// <returns>Updated owner</returns>
        public async Task<UpdateOwnerResponse> UpdateOwnerAsync(UpdateOwnerRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateOwnerResponse(request.CorrelationId());
            _logger.LogInformation($"Update Owner Request - {request.CorrelationId()}");
            var ownerToUpdate = await _asyncRepository.GetByIdAsync(request.Id, cancellationToken);

            ownerToUpdate.UpdateProperties(
                name: request.Name,
                address: request.Address,
                photo: request.Photo,
                birthday: request.Birthday,
                modifiedBy: request.ModifiedBy,
                state: request.State);

            var result = await _asyncRepository.UpdateAsync(ownerToUpdate, cancellationToken);
            if (result == null)
                response.Message = "Error to update owner";

            response.OwnerDto = _mapper.Map<OwnerDto>(result);
            return response;
        }

        /// <summary>
        /// Delete owner 
        /// </summary>
        /// <param name="request">owner requested</param>
        /// <param name="cancellationToken">Cancellation event</param>
        /// <returns>Deleted owner</returns>
        public async Task<DeleteOwnerResponse> DeleteOwnerAsync(DeleteOwnerRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteOwnerResponse(request.CorrelationId());
            _logger.LogInformation($"Delete Owner Request - {request.CorrelationId()}");
            var ownerToDelete = await _asyncRepository.GetByIdAsync(request.OwnerId, cancellationToken);

            var result = await _asyncRepository.DeleteAsync(ownerToDelete, cancellationToken);
            if (result == null)
                response.Message = "Error to delete owner";

            response.OwnerDto = _mapper.Map<OwnerDto>(result);
            return response;
        }

        /// <summary>
        /// Get owner by id
        /// </summary>
        /// <param name="request">request </param>
        /// <param name="cancellationToken">cancellation </param>
        /// <returns>Owner requested</returns>
        public async Task<GetOwnerByIdResponse> GetOwnerByIdAsync(GetOwnerByIdRequest request, CancellationToken cancellationToken)
        {
            var response = new GetOwnerByIdResponse(request.CorrelationId());
            _logger.LogInformation($"Get Owner By Id Request - {request.CorrelationId()}");
            var result = await _asyncRepository.GetByIdAsync(request.OwnerId, cancellationToken);
            if (result == null)
                response.Message = "Error to get owner";

            response.OwnerDto = _mapper.Map<OwnerDto>(result);
            return response;
        }

        /// <summary>
        /// List owners 
        /// </summary>
        /// <param name="cancellationToken">Cancellation event</param>
        /// <returns>Listed owners</returns>
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
