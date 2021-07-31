﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;
using Weelo.Core.BaseEndpoints.PropertyImage;
using Weelo.Core.Dtos;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Services
{
    public class PropertyImageService : IPropertyImageService
    {
        private readonly IAsyncRepository<PropertyImage> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PropertyImageService> _logger;

        public PropertyImageService(IAsyncRepository<PropertyImage> asyncRepository, IMapper mapper, ILogger<PropertyImageService> logger)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreatePropertyImageResponse> CreatePropertyImageAsync(CreatePropertyRequest request, CancellationToken cancellationToken)
        {
            var response = new CreatePropertyImageResponse(request.CorrelationId);
            _logger.LogInformation($"Create PropertyImage Request - {request.CorrelationId}");
            var property = _mapper.Map<PropertyImage>(request);
            var result = await _asyncRepository.AddAsync(property, cancellationToken);
            if (result == null)
                response.Message = "Error to create property image";

            response.PropertyDto = _mapper.Map<PropertyImageDto>(result);
            return response;
        }


        public async Task<UpdatePropertyImageResponse> UpdatePropertyImageAsync(UpdatePropertyImageRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdatePropertyImageResponse(request.CorrelationId);
            _logger.LogInformation($"Update PropertyImage Request - {request.CorrelationId}");
            var propertyToUpdate = await _asyncRepository.GetByIdAsync(request.PropertyImageId, cancellationToken);

            propertyToUpdate.UpdateProperties(
                propertyId: request.PropertyImageDto.PropertyId,
                file: request.PropertyImageDto.File,
                enabled: request.PropertyImageDto.Enabled,
                modifiedBy: request.PropertyImageDto.ModifiedBy,
                state: request.PropertyImageDto.State);

            var result = await _asyncRepository.UpdateAsync(propertyToUpdate, cancellationToken);
            if (result == null)
                response.Message = "Error to update property image";

            response.PropertyDto = _mapper.Map<PropertyImageDto>(result);
            return response;
        }

        public async Task<DeletePropertyImageResponse> DeletePropertyAsync(DeletePropertyImageRequest request, CancellationToken cancellationToken)
        {
            var response = new DeletePropertyImageResponse(request.CorrelationId);
            _logger.LogInformation($"Delete PropertyImage Request - {request.CorrelationId}");
            var ownerToDelete = await _asyncRepository.GetByIdAsync(request.PropertyImageId, cancellationToken);

            var result = await _asyncRepository.DeleteAsync(ownerToDelete, cancellationToken);
            if (result == null)
                response.Message = "Error to delete property image";

            response.PropertyImageDto = _mapper.Map<PropertyImageDto>(result);
            return response;
        }

        public async Task<GetPropertyImageByIdResponse> GetPropertyImageByIdAsync(GetByIdProertyImageRequest request, CancellationToken cancellationToken)
        {
            var response = new GetPropertyImageByIdResponse(request.CorrelationId);
            _logger.LogInformation($"Get PropertyImage By Id Request - {request.CorrelationId}");
            var result = await _asyncRepository.GetByIdAsync(request.PropertyId, cancellationToken);
            if (result == null)
                response.Message = "Error to get property image";

            response.PropertyDto = _mapper.Map<PropertyImageDto>(result);
            return response;
        }

        public async Task<ListPropertyImageResponse> ListPropertyImageAsync(CancellationToken cancellationToken)
        {
            var response = new ListPropertyImageResponse();
            _logger.LogInformation($"List PropertyImage Request - Get");
            var result = await _asyncRepository.ListAllAsync(cancellationToken);
            if (result == null)
                response.Message = "Error to get properties images";
            if (result.Any())
                response.PropertiesImage.AddRange(result.Select(_mapper.Map<PropertyImageDto>));

            return response;
        }
    }
}
