using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;
using Weelo.Core.Dtos;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IAsyncRepository<Property> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PropertyService> _logger;

        public PropertyService(IAsyncRepository<Property> asyncRepository, IMapper mapper, ILogger<PropertyService> logger)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreatePropertyResponse> CreatePropertyAsync(CreatePropertyRequest request, CancellationToken cancellationToken)
        {
            var response = new CreatePropertyResponse(request.CorrelationId);
            _logger.LogInformation($"Create Property Request - {request.CorrelationId}");
            var property = _mapper.Map<Property>(request);
            var result = await _asyncRepository.AddAsync(property, cancellationToken);
            if (result == null)
                response.Message = "Error to create property";

            response.PropertyDto = _mapper.Map<PropertyDto>(result);
            return response;
        }


        public async Task<UpdatePropertyResponse> UpdatePropertyAsync(UpdatePropertyRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdatePropertyResponse(request.CorrelationId);
            _logger.LogInformation($"Update Property Request - {request.CorrelationId}");
            var propertyToUpdate = await _asyncRepository.GetByIdAsync(request.PropertyId, cancellationToken);

            propertyToUpdate.UpdateProperties(
                name: request.PropertyDto.Name,
                address: request.PropertyDto.Address,
                price: request.PropertyDto.Price,
                codeInternal: request.PropertyDto.CodeInternal,
                year: request.PropertyDto.Year,
                ownerId: request.PropertyDto.OwnerId,
                calification: request.PropertyDto.Calification,
                rating: request.PropertyDto.Rating,
                modifiedBy: request.PropertyDto.ModifiedBy,
                state: request.PropertyDto.State);

            var result = await _asyncRepository.UpdateAsync(propertyToUpdate, cancellationToken);
            if (result == null)
                response.Message = "Error to update property";

            response.PropertyDto = _mapper.Map<PropertyDto>(result);
            return response;
        }

        public async Task<DeletePropertyResponse> DeletePropertyAsync(DeletePropertyRequest request, CancellationToken cancellationToken)
        {
            var response = new DeletePropertyResponse(request.CorrelationId);
            _logger.LogInformation($"Delete Property Request - {request.CorrelationId}");
            var ownerToDelete = await _asyncRepository.GetByIdAsync(request.PropertyId, cancellationToken);

            var result = await _asyncRepository.DeleteAsync(ownerToDelete, cancellationToken);
            if (result == null)
                response.Message = "Error to delete property";

            response.PropertyDto = _mapper.Map<PropertyDto>(result);
            return response;
        }

        public async Task<GetPropertyByIdResponse> GetPropertyByIdAsync(GetByIdProertyRequest request, CancellationToken cancellationToken)
        {
            var response = new GetPropertyByIdResponse(request.CorrelationId);
            _logger.LogInformation($"Get Property By Id Request - {request.CorrelationId}");
            var result = await _asyncRepository.GetByIdAsync(request.PropertyId, cancellationToken);
            if (result == null)
                response.Message = "Error to get property";

            response.PropertyDto = _mapper.Map<PropertyDto>(result);
            return response;
        }

        public async Task<ListPropertyResponse> ListPropertyAsync(CancellationToken cancellationToken)
        {
            var response = new ListPropertyResponse();
            _logger.LogInformation($"List Property Request - Get");
            var result = await _asyncRepository.ListAllAsync(cancellationToken);
            if (result == null)
                response.Message = "Error to get properties";
            if (result.Any())
                response.Properties.AddRange(result.Select(_mapper.Map<PropertyDto>));

            return response;
        }

    }
}
