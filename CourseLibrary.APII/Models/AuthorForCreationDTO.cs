using CourseLibrary.APII.Entities;

namespace CourseLibrary.APII.Models
{
    public class AuthorForCreationDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateofBirth { get; set; }
        public string MainCategory { get; set; }
        public ICollection<CourseForCreateionDTO> Courses { get; set; }
        = new List<CourseForCreateionDTO>();
    }
}
