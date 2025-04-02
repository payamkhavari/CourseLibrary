using CourseLibrary.APII.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CourseLibrary.APII.ValidationAttributes;

namespace CourseLibrary.APII.Models
{
    public class CourseForCreateionDTO : CourseForManipulationDTO
    {
        //with write virtual keyword in this property we can change it whenever we want
        //if we define this property abstract we should emplement this in the child class
        // but now we did not have any error and if we want to change it we can change it or override that



        [Required(ErrorMessage ="You should fill out a description.")]
        public override string Description { get => base.Description; set => base.Description = value; }
    }
}
