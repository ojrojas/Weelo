using AutoMapper;
using System.Threading.Tasks;
using Weelo.Core.BaseEndpoints.Property;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Services
{
    public class PropertyService
    {
        private readonly IAsyncRepository<Property> _asyncRepository;
        private readonly IMapper _mapper;

        public PropertyService(IAsyncRepository<Property> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

    }
}
