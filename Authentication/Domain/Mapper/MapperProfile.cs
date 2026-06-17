using Authentication.Data;
using Authentication.Domain.Dto;
using AutoMapper;

namespace Authentication.Domain.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Contact, RegisterUserDto>().ReverseMap();
        }
    }
}
