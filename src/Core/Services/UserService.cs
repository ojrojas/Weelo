using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.User;
using Weelo.Core.Dtos;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IAsyncRepository<User> _asyncRepository;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        public UserService(IAsyncRepository<User> asyncRepository, ILogger<UserService> logger, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateUserResponse(request.CorrelationId);
            _logger.LogInformation($"Create User Request - {request.CorrelationId}");
            var owner = _mapper.Map<User>(request);
            var result = await _asyncRepository.AddAsync(owner, cancellationToken);
            if (result == null)
                response.Message = "Error to create user";

            response.UserDto = _mapper.Map<UserDto>(result);
            return response;
        }

        public async Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateUserResponse(request.CorrelationId);
            _logger.LogInformation($"Update User Request - {request.CorrelationId}");
            var userToUpdate = await _asyncRepository.GetByIdAsync(request.UserId, cancellationToken);

            userToUpdate.UpdateProperties(
                name: request.UserDto.Name,
                lastName: request.UserDto.LastName,
                userName: request.UserDto.UserName,
                password: request.UserDto.Password,
                modifiedBy: request.UserDto.ModifiedBy,
                state: request.UserDto.State);

            var result = await _asyncRepository.UpdateAsync(userToUpdate, cancellationToken);
            if (result == null)
                response.Message = "Error to update user";

            response.UserDto = _mapper.Map<UserDto>(result);
            return response;
        }


        public async Task<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteUserResponse(request.CorrelationId);
            _logger.LogInformation($"Delete User Request - {request.CorrelationId}");
            var ownerToDelete = await _asyncRepository.GetByIdAsync(request.UserId, cancellationToken);

            var result = await _asyncRepository.DeleteAsync(ownerToDelete, cancellationToken);
            if (result == null)
                response.Message = "Error to delete user";

            response.UserDto = _mapper.Map<UserDto>(result);
            return response;
        }

        public async Task<GetUserByIdResponse> GetUserByIdAsync(GetUserByIdResquest request, CancellationToken cancellationToken)
        {
            var response = new GetUserByIdResponse(request.CorrelationId);
            _logger.LogInformation($"Get User By Id Request - {request.CorrelationId}");
            var result = await _asyncRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (result == null)
                response.Message = "Error to get user";

            response.UserDto = _mapper.Map<UserDto>(result);
            return response;
        }

        public async Task<ListUserResponse> ListUserAsync(CancellationToken cancellationToken)
        {
            var response = new ListUserResponse();
            _logger.LogInformation($"List Owners Request - Get");
            var result = await _asyncRepository.ListAllAsync(cancellationToken);
            if (result == null)
                response.Message = "Error to get owner";
            if (result.Any())
                response.Users.AddRange(result.Select(_mapper.Map<UserDto>));

            return response;
        }
    }
}
