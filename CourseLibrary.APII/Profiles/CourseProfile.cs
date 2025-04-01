using AutoMapper;
using CourseLibrary.APII.Entities;
using CourseLibrary.APII.Models;

namespace CourseLibrary.APII.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course,CourseDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId)).ReverseMap();


            CreateMap<CourseForCreateionDTO, Course>();
        }
    }
}
