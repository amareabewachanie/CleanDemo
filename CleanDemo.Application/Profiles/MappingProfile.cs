using AutoMapper;
using CleanDemo.Application.Features.Births.Commands.Create;
using CleanDemo.Domain.Entities;


namespace CleanDemo.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBirthCommand, Birth>().ReverseMap();
            CreateMap<Birth, CreateBirthDto>().ReverseMap();
        }
    }
}
