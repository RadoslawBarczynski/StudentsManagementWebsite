using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolGradeManager.Models
{
    [Table("Logs")]
    public class Logs
    {
        [Key]
        public Guid id { get; set; }

        [Column("comment")]
        public string comment { get; set; }

        [Column("datetime")]
        public DateTime datetime { get; set; }

        [Column("user")]
        public string Username { get; set; }



    }
}
