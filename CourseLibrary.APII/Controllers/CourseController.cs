using AutoMapper;
using CourseLibrary.APII.Entities;
using CourseLibrary.APII.Models;
using CourseLibrary.APII.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CourseLibrary.APII.Controllers
{
    [ApiController]
    [Route("api/Author/authorId/Course")]
    public class CourseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICourseLibraryRepository _repository;

        public CourseController(IMapper mapper, ICourseLibraryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CourseDTO>> GetCoursesForAuthor(Guid authorId)
        {
            var author = _repository.GetAuthor(authorId);

            if (author == null)
            {
                return NotFound();
            }
            var courseForAuthorFromRepo = _repository.GetCourses(authorId);
            return Ok(_mapper.Map<IEnumerable<CourseDTO>>(courseForAuthorFromRepo));
        }

        [HttpGet("courseId", Name = "GetCourseAuthor")]
        public ActionResult<CourseDTO> GetCourseAuthor(Guid authorId, Guid courseId)
        {
            var author = _repository.GetAuthor(authorId);

            if (author == null)
            {
                return Problem(
                    "This Author Not Found",
                    instance: HttpContext.Request.Path,
                    statusCode: StatusCodes.Status422UnprocessableEntity,
                    title: "GetCourseAuthor method");
            }

            var course = _repository.GetCourse(authorId, courseId);

            if (course == null)
            {
                return Problem(
                    detail: "See the erros property for details.",
                    instance: HttpContext.Request.Path,
                    StatusCodes.Status422UnprocessableEntity,
                    title: $"This Course with {courseId} can not be found"
                    );
            }

            return Ok(_mapper.Map<CourseDTO>(course));
        }

        [HttpPost]
        public ActionResult<CourseDTO> CreateCourseForAuthor(Guid authorId, CourseForCreateionDTO course)
        {
            var author = _repository.GetAuthor(authorId);

            if (author == null)
            {
                return NotFound();
            }
            var courseEntity = _mapper.Map<Course>(course);

            courseEntity.AuthorId = authorId;

            _repository.AddCourse(authorId, courseEntity);

            var finalCourse = _mapper.Map<CourseDTO>(courseEntity);

            return CreatedAtRoute("GetCourseAuthor", new { courseId = finalCourse.Id }, finalCourse);
        }

        [HttpPut("{courseId}")]
        public ActionResult<CourseDTO> UpdateCourseForAuthor(Guid authorId, Guid courseId, CourseForCreateionDTO course)
        {
            var author = _repository.GetAuthor(authorId);

            if (author == null)
            {
                return NotFound();
            }
            var courseForAuthorFromRepo = _repository.GetCourse(authorId, courseId);

            if (courseForAuthorFromRepo == null)
            {
                return NotFound();
            }
            //var ExistingCourse =_mapper.Map(course, courseForAuthorFromRepo);
            var newCourse = _mapper.Map<Course>(course);
            newCourse.AuthorId = authorId;
            newCourse.Id = courseId;

            var result = _repository.UpdateCourse(newCourse);

            var finalCourse = _mapper.Map<CourseDTO>(result);

            return Ok(finalCourse);
        }

        [HttpDelete("{courseId}")]
        public IActionResult DeleteCourseForAuthor(Guid courseId ,Guid authorId) 
        { 
            var existingAuthor = _repository.GetAuthor(authorId);  
            if(existingAuthor == null)
            {
                return NotFound(); 
            }
            var existingCourse = _repository.GetCourse(authorId,courseId);
            if (existingCourse == null)
            {
                return NotFound();
            }

            _repository.DeleteCourse(courseId, authorId);
            return NoContent();
        }
    }
}
