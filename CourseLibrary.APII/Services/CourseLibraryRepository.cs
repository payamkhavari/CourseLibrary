using CourseLibrary.APII.DbContexts;
using CourseLibrary.APII.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CourseLibrary.APII.Services
{
    public class CourseLibraryRepository : ICourseLibraryRepository
    {
        private readonly CourseLibraryDbContext _context;
        public CourseLibraryRepository(CourseLibraryDbContext context)
        {
            _context = context;
        }

        public bool IsAuthorExists(Guid AuthorId)
        {
            var author = _context.Authors.FirstOrDefault(n => n.Id == AuthorId);
            if (author == null)
            {
                return false;
            }
            return true;
        }

        public Author GetAuthor(Guid authorId)
        {
            var author = _context.Authors.FirstOrDefault(n => n.Id == authorId);

            return author;
        }

        public IEnumerable<Author> GetAllAuthorByFilter(string mainCategory)
        {
            if (string.IsNullOrWhiteSpace(mainCategory))
            {
                return GetAuthors();
            }
            mainCategory = mainCategory.Trim();
            var result = _context.Authors.Where(n => n.MainCategory == mainCategory).ToList();
            return result;
        }

        public List<Author> GetAuthors()
        {
            var authors = _context.Authors.ToList();

            return authors;
        }

        public IEnumerable<Author> GetAuthorsBySearching(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return GetAuthors();
            }
            searchQuery = searchQuery.Trim();
            var authors = _context.Authors as IQueryable<Author>;

            authors = authors.Where(a => a.MainCategory.Contains(searchQuery)
            || a.FirstName.Contains(searchQuery) || a.LastName.Contains(searchQuery));

            return authors.ToList();
        }

        public List<Course> GetCourses(Guid authorId)
        {
            var courses = _context.Courses.Where(n => n.AuthorId == authorId).ToList();
            //var authors =  _context.Courses.Include(n => n.Author).ToList();
            // authors = authors.Where(n => n.Id == authorId).ToList();

            return courses;
        }

        public Course GetCourse(Guid authorId, Guid courseId)
        {
            var courses = _context.Courses.FirstOrDefault(n => n.AuthorId == authorId && n.Id == courseId);
            return courses;
        }

        public Author AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        public Course AddCourse(Guid authorId, Course course)
        {
            var author = _context.Authors.FirstOrDefault(n => n.Id == authorId);

            if(author == null)
            {
                throw new Exception("this Author id cannot be found!!");
            }

            var newCourse = new Course()
            {
                Id = Guid.NewGuid(),
                AuthorId = authorId,
                Description = course.Description,
                Title = course.Title,
            };
            _context.Courses.Add(newCourse);
            _context.SaveChanges();
            return newCourse;
        }
    }
}
