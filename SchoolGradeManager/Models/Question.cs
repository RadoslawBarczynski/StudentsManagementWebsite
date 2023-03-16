using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolGradeManager.Models
{
    [Table("Question")]
    public class Question
    {
        [Key]
        public Guid id { get; set; }

        [DisplayName("Operation")]
        [Required(ErrorMessage = "Instert operation to calculate")]
        public string operation { get; set; }

        [DisplayName("Correct answer")]
        [Required(ErrorMessage = "Instert correct answer")]
        public double answer1 { get; set; }

        [DisplayName("Incorrect answer 1")]
        [Required(ErrorMessage = "Instert incorrect answer")]
        public double answer2 { get; set; }

        [DisplayName("Incorrect answer 2")]
        [Required(ErrorMessage = "Instert incorrect answer")]
        public double answer3 { get; set; }
    }
}
