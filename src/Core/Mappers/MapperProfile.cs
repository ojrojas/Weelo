using AutoMapper;
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
                 //.ForMember(x => x.Id, map => map.MapFrom(dto => dto.Id))
                 //.ForMember(x => x.Id, map => map.MapFrom(dto => dto.Id))
                 //.ForMember(x => x.Id, map => map.MapFrom(dto => dto.Id))
                 //.ForMember(x => x.Id, map => map.MapFrom(dto => dto.Id))
                 //.ForMember(x => x.Id, map => map.MapFrom(dto => dto.Id))
                 //.ForMember(x => x.Id, map => map.MapFrom(dto => dto.Id))

            CreateMap<Property, Property>();
            CreateMap<PropertyImage, PropertyImageDto>();
            CreateMap<PropertyTrace, PropertyTraceDto>();
            CreateMap<User, UserDto>();
        }
    }
}
