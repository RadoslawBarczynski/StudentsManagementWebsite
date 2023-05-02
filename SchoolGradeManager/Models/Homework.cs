using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolGradeManager.Models
{
    [Table("Homework")]
    public class Homework
    {
        [Key]
        public Guid id { get; set; }

        [Column("ScoreToGet")]
        public int ScoreToGet { get; set; }

        [Column("GameNumber")]
        public int GameNumber { get; set; }

        [Column("isActive")]
        public bool isActive { get; set; }

    }
}
