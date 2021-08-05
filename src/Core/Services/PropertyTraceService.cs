using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.PropertyTrace;
using Weelo.Core.Dtos;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Services
{
    public class PropertyTraceService : IPropertyTraceService
    {
        private readonly IAsyncRepository<PropertyTrace> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PropertyTraceService> _logger;

        public PropertyTraceService(IAsyncRepository<PropertyTrace> asyncRepository, IMapper mapper, ILogger<PropertyTraceService> logger)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreatePropertyTraceResponse> CreatePropertyTraceAsync(CreatePropertyTraceRequest request, CancellationToken cancellationToken)
        {
            var response = new CreatePropertyTraceResponse(request.CorrelationId);
            _logger.LogInformation($"Create PropertyTrace Request - {request.CorrelationId}");
            var property = new PropertyTrace
            {
                Name = request.Name,
                State = true,
                PropertyId = request.PropertyId,
                Tax = request.Tax,
                Value = request.Value,
                CreatedBy = request.CreatedBy, 
                CreatedOn = DateTime.Now
            };
            var result = await _asyncRepository.AddAsync(property, cancellationToken);
            if (result == null)
                response.Message = "Error to create property trace";

            response.PropertyDto = _mapper.Map<PropertyTraceDto>(result);
            return response;
        }


        public async Task<UpdatePropertyTraceResponse> UpdatePropertyTraceAsync(UpdatePropertyTraceRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdatePropertyTraceResponse(request.CorrelationId);
            _logger.LogInformation($"Update PropertyTrace Request - {request.CorrelationId}");
            var propertyToUpdate = await _asyncRepository.GetByIdAsync(request.Id, cancellationToken);

            propertyToUpdate.UpdateProperties(
                propertyId: request.PropertyId,
                dateSale: request.DateSale,
                name: request.Name,
                value: request.Value,
                tax: request.Tax,
                modifiedBy: request.ModifiedBy,
                state: request.State);

            var result = await _asyncRepository.UpdateAsync(propertyToUpdate, cancellationToken);
            if (result == null)
                response.Message = "Error to update property trace";

            response.PropertyTraceDto = _mapper.Map<PropertyTraceDto>(result);
            return response;
        }

        public async Task<DeletePropertyTraceResponse> DeletePropertyTraceAsync(DeletePropertyTraceRequest request, CancellationToken cancellationToken)
        {
            var response = new DeletePropertyTraceResponse(request.CorrelationId);
            _logger.LogInformation($"Delete PropertyTrace Request - {request.CorrelationId}");
            var ownerToDelete = await _asyncRepository.GetByIdAsync(request.PropertyTraceId, cancellationToken);

            var result = await _asyncRepository.DeleteAsync(ownerToDelete, cancellationToken);
            if (result == null)
                response.Message = "Error to delete property trace";

            response.PropertyTraceDto = _mapper.Map<PropertyTraceDto>(result);
            return response;
        }

        public async Task<GetByIdPropertyTraceResponse> GetByIdPropertyTraceAsync(GetByIdPropertyTraceRequest request, CancellationToken cancellationToken)
        {
            var response = new GetByIdPropertyTraceResponse(request.CorrelationId);
            _logger.LogInformation($"Get PropertyTrace By Id Request - {request.CorrelationId}");
            var result = await _asyncRepository.GetByIdAsync(request.PropertyTraceId, cancellationToken);
            if (result == null)
                response.Message = "Error to get property trace";

            response.PropertyTraceDto = _mapper.Map<PropertyTraceDto>(result);
            return response;
        }

        public async Task<ListPropertyTraceResponse> ListPropertyTraceAsync(CancellationToken cancellationToken)
        {
            var response = new ListPropertyTraceResponse();
            _logger.LogInformation($"List PropertyTrace Request - Get");
            var result = await _asyncRepository.ListAllAsync(cancellationToken);
            if (result == null)
                response.Message = "Error to get properties traces";
            if (result.Any())
                response.PropertiesTrace.AddRange(result.Select(_mapper.Map<PropertyTraceDto>));

            return response;
        }
    }
}
