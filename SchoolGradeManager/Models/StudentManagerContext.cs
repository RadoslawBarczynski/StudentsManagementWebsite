using Microsoft.EntityFrameworkCore;

namespace SchoolGradeManager.Models
{
    public class StudentManagerContext : DbContext
    {
        public StudentManagerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> students { get; set; }
    }
}
