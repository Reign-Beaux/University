using AutoMapper;
using University.BL.DTOs;
using University.Data;
using University.Data.Models;
using University.Data.StoreProcedures;

namespace University.BL.Services
{
    public class CourseService
    {
        private readonly CourseSP sp;
        private readonly IMapper mapper;

        public CourseService(UniversityContext context, IMapper mapper)
        {
            this.sp = new CourseSP(context);
            this.mapper = mapper;
        }

        public async Task<List<CourseDTO>> GetAll()
        {
            var courses = await sp.GetAll();
            var coursesDTO = mapper.Map<List<CourseDTO>>(courses);

            return coursesDTO;
        }

        public async Task<CourseDTO> GetById(int id)
        {
            var course = await sp.GetById(id);
            var courseDTO = mapper.Map<CourseDTO>(course);

            return courseDTO;
        }

        public async Task Post(CourseDTO courseParam)
        {
            var course = mapper.Map<Course>(courseParam);
            await sp.Post(course);
        }

        public async Task Put(int id, CourseDTO courseParam)
        {
            var course = mapper.Map<Course>(courseParam);
            await sp.Put(id, course);
        }

        public async Task Delete(int id)
            => await sp.Delete(id);
    }
}
