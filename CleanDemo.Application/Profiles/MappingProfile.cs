using AutoMapper;
using CleanDemo.Application.Features.Births.Commands.Create;
using CleanDemo.Application.Features.Births.Commands.Update;
using CleanDemo.Application.Features.Births.Queries.Get;
using CleanDemo.Application.Features.Births.Queries.List;
using CleanDemo.Domain.Entities;


namespace CleanDemo.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBirthCommand, Birth>().ReverseMap();
            CreateMap<Birth, CreateBirthDto>().ReverseMap();
            CreateMap<Birth, UpdateBirthDto>().ReverseMap();
            CreateMap<Birth, UpdateBirthCommand>().ReverseMap();
            CreateMap<BirthVm, Birth>().ReverseMap();
            CreateMap<BirthsVm,Birth>().ReverseMap();
        }
    }
}
