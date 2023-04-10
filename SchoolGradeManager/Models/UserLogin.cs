using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolGradeManager.Models
{
    public class UserLogin
    {
        [Key]
        public Guid id { get; set; }
        [Required(ErrorMessage = "Please Enter Username")]
        [Display(Name = "Username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}
