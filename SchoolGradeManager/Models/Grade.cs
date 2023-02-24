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

        [Column("Math")]
        public string G_Math { get; set; }
        [Column("English")]
        public string G_English { get; set; }
        [Column("Biology")]
        public string G_Biology { get; set; }
        [Column("History")]
        public string G_History { get; set; }
        [Column("Geography")]
        public string G_Geography { get; set; }
        [Column("PE")]
        public string G_PE { get; set; }

        public virtual Student student { get; set; }

    }
}
