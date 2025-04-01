using CourseLibrary.APII.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CourseLibrary.APII.ValidationAttributes;

namespace CourseLibrary.APII.Models
{
    [CourseTitleDifferentFromDescription]
    public class CourseForCreateionDTO /*: IValidatableObject*/
    {
        [Required]
        [MaximumOfTitleInCourseClass]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(3000)]
        public string Description { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title == Description)
        //    {
        //        yield return new ValidationResult(
        //            "The provided description should be different from the Title",
        //            new[] { "CourseForCreateionDTO" });

        //    }

        //    if (Title.Length == 0)
        //    {
        //        yield return new ValidationResult(
        //            "you should input at least 2 character in this part.",
        //            new[] { "Title" }
        //            );
        //    }
        //}
    }
}
