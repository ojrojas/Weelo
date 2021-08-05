using AutoMapper;
using Weelo.Core.BaseEndpoints.User;
using Weelo.Core.Dtos;
using Weelo.Core.Entities;

namespace Weelo.Core.Mappers
{
    /// <summary>
    /// Profile Mapper Weelo Application
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/07/2021</date>
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Owner, OwnerDto>();
                 //.ForMember(x => x.Id, map => map.MapFrom(dto => dto.Id))
           

            CreateMap<Property, PropertyDto>().ReverseMap(); ;
            CreateMap<PropertyImage, PropertyImageDto>().ReverseMap(); ;
            CreateMap<PropertyTrace, PropertyTraceDto>().ReverseMap(); ;
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
