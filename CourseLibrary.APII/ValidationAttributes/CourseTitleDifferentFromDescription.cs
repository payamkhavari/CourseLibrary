using CourseLibrary.APII.Models;
using System;
using System.ComponentModel.DataAnnotations;


namespace CourseLibrary.APII.ValidationAttributes
{
    public class CourseTitleDifferentFromDescription : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var course = (CourseForCreateionDTO)validationContext.ObjectInstance;

            if(course.Title == course.Description)
            {
                return new ValidationResult(
                    "The Provided Description Should Be Different From The Title.",
                    new[] {nameof(CourseForCreateionDTO)}
                    );
            }
            return ValidationResult.Success;
        }
    }
}
