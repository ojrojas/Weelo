using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Weelo.Core.Dtos;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Services
{
    public class OwnerService
    {
        private readonly IAsyncRepository<Owner> _asyncRepository;
        private readonly ILogger<OwnerService> _logger;

        public OwnerService(IAsyncRepository<Owner> asyncRepository, ILogger<OwnerService> logger)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
        }

        public async Task<OwnerDto> Create(OwnerDto owner)
        {
            await Task.CompletedTask;
            return null;
        }
    }
}
