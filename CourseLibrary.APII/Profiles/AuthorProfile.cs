using AutoMapper;
using CourseLibrary.APII.Entities;
using CourseLibrary.APII.Helpers;
using CourseLibrary.APII.Models;
using Microsoft.AspNetCore.Routing.Constraints;

namespace CourseLibrary.APII.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDTO>()
                .ForMember(
                dis => dis.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                dis => dis.Age,
                opt => opt.MapFrom(src => src.DateofBirth.GetCurrentAge()));

            CreateMap<AuthorForCreationDTO, Author>();

        }
    }
}
