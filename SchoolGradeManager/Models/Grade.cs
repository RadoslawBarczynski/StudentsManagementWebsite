using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolGradeManager.Models
{
    [Table("Grade")]
    public class Grade
    {
        [Key]
        [ForeignKey("Student")]
        public int GradeId { get; set; }

        [Column("Score")]
        public int G_Score { get; set; }

        public virtual Student student { get; set; }

    }
}
