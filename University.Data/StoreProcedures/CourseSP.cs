using Microsoft.EntityFrameworkCore;
using University.Data.Models;

namespace University.Data.StoreProcedures
{
    public class CourseSP
    {
        private readonly UniversityContext context;

        public CourseSP(UniversityContext context)
        {
            this.context = context;
        }

        public async Task<IAsyncEnumerable<Course>> GetAll()
        {
            IAsyncEnumerable<Course> courses = context.Courses
                                                      .FromSqlInterpolated($"EXEC CourseGetAll")
                                                      .AsAsyncEnumerable();
            return courses;
        }

        public async Task<Course> GetById(int id)
        {
            IAsyncEnumerable<Course> courses = context.Courses
                                                      .FromSqlInterpolated($"EXEC CourseGetById @CourseID={id}")
                                                      .AsAsyncEnumerable();
            await foreach (Course course in courses)
            {
                return course;
            }

            return null;
        }

        public async Task Post(Course courseParams)
            => await context.Database
                            .ExecuteSqlInterpolatedAsync($@"EXEC CoursePost @CourseID={courseParams.CourseId}, @Title={courseParams.Title}, @Credits={courseParams.Credits}");

        public async Task Put(int id, Course courseParams)
            => await context.Database
                            .ExecuteSqlInterpolatedAsync($@"EXEC CoursePut @OriginalCourseID={id}, @CourseID={courseParams.CourseId}, @Title={courseParams.Title}, @Credits={courseParams.Credits}");
        
        public async Task Delete(int id)
            => await context.Database
                            .ExecuteSqlInterpolatedAsync($@"EXEC CourseDelete @CourseID={id}");
    }
}
