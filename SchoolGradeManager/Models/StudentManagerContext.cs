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

            modelBuilder.Entity<TestQuestion>()
                .HasOne(t => t.test)
                .WithMany(ba => ba.TestQuestions)
                .HasForeignKey(bi => bi.TestId);

            modelBuilder.Entity<TestQuestion>()
                .HasOne(t => t.question)
                .WithMany(ba => ba.TestQuestions)
                .HasForeignKey(bi => bi.QuestionId);

        }

        public DbSet<Student> students { get; set; }
        public DbSet<Grade> grades { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Test> tests { get; set; }

        public DbSet<TestQuestion> TestQuestions { get; set; }  

    }
}
