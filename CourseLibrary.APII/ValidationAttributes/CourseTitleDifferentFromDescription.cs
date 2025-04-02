using CourseLibrary.APII.Models;
using System;
using System.ComponentModel.DataAnnotations;


namespace CourseLibrary.APII.ValidationAttributes
{
    public class CourseTitleDifferentFromDescription : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var course = (CourseForManipulationDTO)validationContext.ObjectInstance;

            if(course.Title == course.Description)
            {
                return new ValidationResult(
                    "The Provided Description Should Be Different From The Title.",
                    new[] {nameof(CourseForManipulationDTO) }
                    );
            }
            return ValidationResult.Success;
        }
    }
}
