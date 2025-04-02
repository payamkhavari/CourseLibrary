using CourseLibrary.APII.Entities;

namespace CourseLibrary.APII.Services
{
    public interface ICourseLibraryRepository
    {
        List<Author> GetAuthors();  
        Author GetAuthor(Guid authorId);
        bool IsAuthorExists(Guid AuthorId);
        List<Course> GetCourses(Guid authorId);
        Course GetCourse(Guid authorId,Guid courseId);
        IEnumerable<Author> GetAllAuthorByFilter(string mainCategory);
        IEnumerable<Author> GetAuthorsBySearching(string searchQuery);
        Author AddAuthor(Author author);
        Course AddCourse(Guid authorId,Course course);
        Course UpdateCourse(Course course);
        void DeleteCourse(Guid courseId,Guid authorId);
    }
}
