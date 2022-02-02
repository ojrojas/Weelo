using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;
using Weelo.Core.BaseEndpoints.PropertyImage;
using Weelo.Core.BaseEndpoints.PropertyTrace;
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

        private readonly IPropertyImageService _propertyImageService;
        private readonly IPropertyTraceService _propertyTraceService;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="asyncRepository">repository entity property</param>
        /// <param name="mapper">mappers</param>
        /// <param name="logger">log application</param>
        /// <param name="propertyImageService">services imageproperty</param>
        /// <param name="propertyTraceService">services traceproperty</param>
        public PropertyService(IAsyncRepository<Property> asyncRepository,
                               IMapper mapper,
                               ILogger<PropertyService> logger,
                               IPropertyImageService propertyImageService,
                               IPropertyTraceService propertyTraceService)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
            _propertyImageService = propertyImageService;
            _propertyTraceService = propertyTraceService;
        }

        /// <summary>
        /// Create property 
        /// </summary>
        /// <param name="request">request property </param>
        /// <param name="cancellationToken">cancellation event</param>
        /// <returns>property created</returns>
        public async Task<CreatePropertyResponse> CreatePropertyAsync(CreatePropertyRequest request, CancellationToken cancellationToken)
        {
            var response = new CreatePropertyResponse(request.CorrelationId());
            _logger.LogInformation($"Create Property Request - {request.CorrelationId()}");
            var property = new Property
            {
                Name = request.Name,
                Address = request.Address,
                Price = request.Price,
                CodeInternal = request.CodeInternal,
                Year = request.Year,
                OwnerId = request.OwnerId,
            };

            property.PropertyImage = new PropertyImage
            {
                File = request.PropertyImage.File,
                PropertyId = property.Id,
                Enabled = !string.IsNullOrEmpty(request.PropertyImage.File),
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.Now
            };

            property.PropertyTrace = new PropertyTrace
            {
                Name = request.PropertyTrace.Name,
                DateSale = request.PropertyTrace.DateSale,
                Value = request.PropertyTrace.Value,
                Tax = request.PropertyTrace.Tax,
                CreatedBy = request.CreatedBy,
                PropertyId = property.Id,
                CreatedOn = DateTime.Now
            };


            var result = await _asyncRepository.AddAsync(property, cancellationToken);
            if (result == null)
            {
                response.Message = "Error to create property";
            }
            else
            {
                property.PropertyImageId = property.PropertyImage.Id;
                property.PropertyTraceId= property.PropertyTrace.Id;

                await _asyncRepository.UpdateAsync(property);
            }

            response.PropertyDto = _mapper.Map<PropertyDto>(result);
            return response;
        }


        /// <summary>
        /// Update property
        /// </summary>
        /// <param name="request">request property</param>
        /// <param name="cancellationToken">cancellation event</param>
        /// <returns>property updated</returns>
        public async Task<UpdatePropertyResponse> UpdatePropertyAsync(UpdatePropertyRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdatePropertyResponse(request.CorrelationId());
            _logger.LogInformation($"Update Property Request - {request.CorrelationId()}");
            var propertyToUpdate = await _asyncRepository.GetByIdAsync(request.Id, cancellationToken);

            var propertyImage = new UpdatePropertyImageRequest
            {
                File = request.PropertyImage.File,
                PropertyId = request.Id,
                Enabled = !string.IsNullOrEmpty(request.PropertyImage.File),
                ModifiedBy = request.ModifiedBy,
                ModifiedOn = DateTime.Now,
                Width = request.PropertyImage.Width,
                Height = request.PropertyImage.Height
            };

            var propertyTrace = new UpdatePropertyTraceRequest
            {
                Name = request.PropertyTrace.Name,
                DateSale = request.PropertyTrace.DateSale,
                Value = request.PropertyTrace.Value,
                Tax = request.PropertyTrace.Tax,
                ModifiedBy = request.ModifiedBy,
                ModifiedOn = DateTime.Now
            };

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
            {
                response.Message = "Error to update property";
            }
            else
            {
                await _propertyImageService.UpdatePropertyImageAsync(propertyImage, cancellationToken);
                await _propertyTraceService.UpdatePropertyTraceAsync(propertyTrace, cancellationToken);
            }

            response.PropertyDto = _mapper.Map<PropertyDto>(result);
            return response;
        }

        /// <summary>
        /// Delete property 
        /// </summary>
        /// <param name="request">request delete</param>
        /// <param name="cancellationToken">cancellation event</param>
        /// <returns>property delete</returns>
        public async Task<DeletePropertyResponse> DeletePropertyAsync(DeletePropertyRequest request, CancellationToken cancellationToken)
        {
            var response = new DeletePropertyResponse(request.CorrelationId());
            _logger.LogInformation($"Delete Property Request - {request.CorrelationId()}");
            var ownerToDelete = await _asyncRepository.GetByIdAsync(request.PropertyId, cancellationToken);

            var result = await _asyncRepository.DeleteAsync(ownerToDelete, cancellationToken);
            if (result == null)
                response.Message = "Error to delete property";

            response.PropertyDto = _mapper.Map<PropertyDto>(result);
            return response;
        }

        /// <summary>
        /// Get property by id
        /// </summary>
        /// <param name="request">property request</param>
        /// <param name="cancellationToken">cancellation event</param>
        /// <returns>property</returns>
        public async Task<GetPropertyByIdResponse> GetPropertyByIdAsync(GetByIdProertyRequest request, CancellationToken cancellationToken)
        {
            var response = new GetPropertyByIdResponse(request.CorrelationId());
            _logger.LogInformation($"Get Property By Id Request - {request.CorrelationId()}");
            var result = await _asyncRepository.GetByIdAsync(request.PropertyId, cancellationToken);
            if (result == null)
                response.Message = "Error to get property";

            response.PropertyDto = _mapper.Map<PropertyDto>(result);
            return response;
        }

        /// <summary>
        /// List properties
        /// </summary>
        /// <param name="cancellationToken">cancellation event</param>
        /// <returns>properties listed</returns>
        public async Task<ListPropertyResponse> ListPropertyAsync(CancellationToken cancellationToken)
        {
            var response = new ListPropertyResponse();
            _logger.LogInformation($"List Property Request - Get");
            var results = await _asyncRepository.ListAllAsync(cancellationToken);
            if (results == null)
                response.Message = "Error to get properties";
            
            if (results.Any())
                response.Properties.AddRange(results.Select(_mapper.Map<PropertyDto>));

            foreach (var i in response.Properties)
            {
                var propertyTrace = await _propertyTraceService.GetByIdPropertyTraceAsync(
                    new GetByIdPropertyTraceRequest { PropertyTraceId = i.PropertyTraceId }, cancellationToken);
                i.PropertyTrace = propertyTrace.PropertyTraceDto;

                var propertyImage = await _propertyImageService.GetPropertyImageByIdAsync(
                   new GetByIdProertyImageRequest { PropertyImageId = i.PropertyImageId}, cancellationToken);
                i.PropertyImage = propertyImage.PropertyImageDto;
            }

            return response;
        }

    }
}
