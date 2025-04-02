using CourseLibrary.APII.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace CourseLibrary.APII.Models
{

    // this is a abstract class that courseForCreation is inherited from this class to 
    // eleminate overwritting in the code
    [CourseTitleDifferentFromDescription]
    public abstract class CourseForManipulationDTO
    {
        [Required]
        [MaximumOfTitleInCourseClass]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(3000)]
        public virtual string Description { get; set; }
    }
}
