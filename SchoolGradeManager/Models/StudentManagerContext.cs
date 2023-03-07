using Microsoft.EntityFrameworkCore;

namespace SchoolGradeManager.Models
{
    public class StudentManagerContext : DbContext
    {
        public StudentManagerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>()
                .HasOne(s => s.student)
                .WithOne(ad => ad.grade)
                .HasForeignKey<Grade>(ad => ad.GradeId);
        }

        public DbSet<Student> students { get; set; }
        public DbSet<Grade> grades { get; set; }

    }
}
