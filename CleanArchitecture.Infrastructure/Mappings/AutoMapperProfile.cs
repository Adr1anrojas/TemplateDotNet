using AutoMapper;
using CleanArchitecture.ApplicationCore.DTOs;
using CleanArchitecture.ApplicationCore.Entities;

namespace CleanArchitecture.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
