using CourseLibrary.APII.Models;
using System.ComponentModel.DataAnnotations;

namespace CourseLibrary.APII.ValidationAttributes
{
    public class MaximumOfTitleInCourseClass:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var course = (CourseForManipulationDTO)validationContext.ObjectInstance;

            if(course.Title.Length >= 100)
            {
                return new ValidationResult(
                    "the Filed of Title could not have more than 100 character!."
                    );
            }
            return ValidationResult.Success;
        }
    }
}
