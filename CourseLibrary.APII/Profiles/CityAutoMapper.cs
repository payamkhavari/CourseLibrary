using AutoMapper;
using CourseLibrary.APII.Entities;
using CourseLibrary.APII.Models;

namespace CourseLibrary.APII.Profiles
{
    public class CityAutoMapper : Profile
    {
        public CityAutoMapper()
        {
            CreateMap<City , CityDTO>()
                .ForMember(
                dis => dis.CityName, 
                opt => opt.MapFrom(src => src.CityName));
        }
    }
}
