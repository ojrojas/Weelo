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
    /// <summary>
    /// User services
    /// </summary>
    /// <auhtor>Oscar Julian Rojas</auhtor>
    /// <date>29/08/2021</date>
    public class UserService : IUserService
    {
        private readonly IAsyncRepository<User> _asyncRepository;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="asyncRepository">reporsitory generic</param>
        /// <param name="logger">logger application</param>
        /// <param name="mapper">mappers entitiens</param>
        public UserService(IAsyncRepository<User> asyncRepository, ILogger<UserService> logger, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="request">user request</param>
        /// <param name="cancellationToken">cancellation event</param>
        /// <returns>User created</returns>
        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateUserResponse(request.CorrelationId());
            _logger.LogInformation($"Create User Request - {request.CorrelationId()}");
            var userDto = new UserDto { 
                Name = request.Name,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
                CreatedBy = request.CreatedBy,
                CreatedOn = request.CreatedOn,
                State = true
            };
            var owner = _mapper.Map<User>(userDto);
            var result = await _asyncRepository.AddAsync(owner, cancellationToken);
            if (result == null)
                response.Message = "Error to create user";

            response.UserDto = _mapper.Map<UserDto>(result);
            return response;
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="request">request user</param>
        /// <param name="cancellationToken">cancellation event</param>
        /// <returns>User Updated</returns>
        public async Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateUserResponse(request.CorrelationId());
            _logger.LogInformation($"Update User Request - {request.CorrelationId()}");
            var userToUpdate = await _asyncRepository.GetByIdAsync(request.Id, cancellationToken);

            userToUpdate.UpdateProperties(
                name: request.Name,
                lastName: request.LastName,
                userName: request.UserName,
                password: request.Password,
                modifiedBy: request.ModifiedBy,
                createdBy:request.CreatedBy,
                createdOn:request.CreatedOn,
                state: request.State);

            var result = await _asyncRepository.UpdateAsync(userToUpdate, cancellationToken);
            if (result == null)
                response.Message = "Error to update user";

            response.UserDto = _mapper.Map<UserDto>(result);
            return response;
        }

        /// <summary>
        /// Delete user 
        /// </summary>
        /// <param name="request">Delete user request</param>
        /// <param name="cancellationToken">cancellation event</param>
        /// <returns>Deleted User</returns>
        public async Task<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteUserResponse(request.CorrelationId());
            _logger.LogInformation($"Delete User Request - {request.CorrelationId()}");
            var ownerToDelete = await _asyncRepository.GetByIdAsync(request.UserId, cancellationToken);

            var result = await _asyncRepository.DeleteAsync(ownerToDelete, cancellationToken);
            if (result == null)
                response.Message = "Error to delete user";

            response.UserDto = _mapper.Map<UserDto>(result);
            return response;
        }

        /// <summary>
        /// Get by id user
        /// </summary>
        /// <param name="request">User request</param>
        /// <param name="cancellationToken">cancellation event</param>
        /// <returns>User search</returns>
        public async Task<GetUserByIdResponse> GetUserByIdAsync(GetUserByIdResquest request, CancellationToken cancellationToken)
        {
            var response = new GetUserByIdResponse(request.CorrelationId());
            _logger.LogInformation($"Get User By Id Request - {request.CorrelationId()}");
            var result = await _asyncRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (result == null)
                response.Message = "Error to get user";

            response.UserDto = _mapper.Map<UserDto>(result);
            return response;
        }

        /// <summary>
        /// List users application
        /// </summary>
        /// <param name="cancellationToken">cancellation event</param>
        /// <returns>Listed users</returns>
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
