using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolGradeManager.Models
{
    [Table("Test")]
    public class Test
    {
        [Key]
        public Guid id { get; set; }

        [DisplayName("TestName")]
        [Required(ErrorMessage = "Instert name of test")]
        public string TestName { get; set; }

        [DisplayName("isActive")]
        public bool isActive { get; set; }

        public virtual List<TestQuestion> TestQuestions { get; set; }

    }
}