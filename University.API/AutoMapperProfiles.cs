using AutoMapper;
using University.BL.DTOs;
using University.Data.Models;

namespace University.API
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Enrollment, EnrollmentDTO>().ReverseMap();
        }
    }
}
