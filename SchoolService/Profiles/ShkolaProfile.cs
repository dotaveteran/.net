using AutoMapper;
using SchoolService.Dtos;
using SchoolService.Models;

namespace SchoolService.Profiles
{
    public class ShkolasProfile : Profile 
    {
        public ShkolasProfile()
        {
            //Source ->Target
            CreateMap<Shkola, ShkolaReadDto>();
            CreateMap<ShkolaCreateDto, Shkola>();
        }
    }
}