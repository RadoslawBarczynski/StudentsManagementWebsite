using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolGradeManager.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public Guid id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Instert Name of the student")]
        public string StudentFirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Instert Last Name of the student")]
        public string StudentLastName { get; set; }

        [DisplayName("Login")]
        [Column("Login")]
        [Required(ErrorMessage = "Instert Email of the student")]
        public string StudentLogin { get; set; }

        [DisplayName("Password")]
        [Column("Password")]
        [Required(ErrorMessage = "Instert Email of the student")]
        public string StudentPassword { get; set; }


        public Guid? GradeId { get; set; }
        public virtual Grade grade { get; set; }

    }
}
