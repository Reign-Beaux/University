using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using University.BL.DTOs;
using University.BL.Services;
using University.Data;

namespace University.API.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly CourseService courseService;

        public CoursesController(UniversityContext context, IMapper mapper)
        {
            this.courseService = new CourseService(context, mapper);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
            => Ok(await courseService.GetAll());


        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var course = await courseService.GetById(id);
            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await courseService.Post(courseDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await courseService.Put(id, courseDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await courseService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}