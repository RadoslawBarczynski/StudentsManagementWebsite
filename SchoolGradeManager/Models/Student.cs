using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolGradeManager.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "Instert Name of the student")]
        public string StudentFirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Instert Last Name of the student")]
        public string StudentLastName { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Instert Email of the student")]
        public string StudentEmail { get; set; }
    }
}
