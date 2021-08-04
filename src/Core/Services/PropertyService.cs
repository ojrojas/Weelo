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
    /// <summary>
    /// Property Services
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class PropertyService : IPropertyService
    {
        /// <summary>
        /// Services WeeloDbContext
        /// </summary>
        private readonly IAsyncRepository<Property> _asyncRepository;
        /// <summary>
        /// Service Mapper Property to PropertyDto
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Services Logger services serilog
        /// </summary>
        private readonly ILogger<PropertyService> _logger;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="asyncRepository">Service WeeloDbConext</param>
        /// <param name="mapper">Service Mapper</param>
        /// <param name="logger">Service logger</param>
        public PropertyService(IAsyncRepository<Property> asyncRepository, IMapper mapper, ILogger<PropertyService> logger)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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
            var propertyToUpdate = await _asyncRepository.GetByIdAsync(request.Id, cancellationToken);

            propertyToUpdate.UpdateProperties(
                name: request.Name,
                address: request.Address,
                price: request.Price,
                codeInternal: request.CodeInternal,
                year: request.Year,
                ownerId: request.OwnerId,
                calification: request.Calification,
                rating: request.Rating,
                propertyImageId: request.PropertyImageId,
                propertyTraceId: request.PropertyTraceId,
                modifiedBy: request.ModifiedBy,
                state: request.State);

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
