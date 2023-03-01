using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolGradeManager.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Column("Login")]
        public string Login { get; set; }
        [Column("Password")]
        public string Password { get; set; }    
    }
}
