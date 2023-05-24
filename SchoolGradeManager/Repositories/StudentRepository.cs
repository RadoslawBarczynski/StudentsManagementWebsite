using Microsoft.EntityFrameworkCore;
using SchoolGradeManager.Models;
using BCrypt.Net;

namespace SchoolGradeManager.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentManagerContext _context;
        public StudentRepository(StudentManagerContext context)
        {
            _context = context;
        }
        public Student Get(Guid id)
        {
            Student student = _context.students.SingleOrDefault(x => x.id.Equals(id));
            //student.grade = _context.grades.SingleOrDefault(y => y.GradeId.Equals(student.GradeId));
            return student;
        }


        public IQueryable<Student> GetAllActive() => _context.students.Include("grade");


        public void Add(Student student)
        {
            Guid myuuid = Guid.NewGuid();
            student.id = myuuid;
            student.StudentPassword = BCrypt.Net.BCrypt.HashPassword(student.StudentPassword, BCrypt.Net.BCrypt.GenerateSalt(12));
            _context.students.Add(student);
            //basic grade template
            Grade grade = new Grade();
            Guid myuuid2 = Guid.NewGuid();
            Console.WriteLine(myuuid2.ToString() + myuuid.ToString());
            grade.G_Score = 0;
            grade.student = student;
            grade.GradeId = myuuid2;

            _context.grades.Add(grade);
            _context.SaveChanges();
            student.GradeId = grade.GradeId;
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var result = _context.students.SingleOrDefault(x => x.id.Equals(id));
            if(result != null)
            {
                var result2 = _context.grades.SingleOrDefault(y => y.GradeId.Equals(result.GradeId));
                if(result2 != null)
                {
                    _context.grades.Remove(result2);
                    _context.SaveChanges();
                }
            }
        }

        public void Update(Guid id, Student student)
        {
            var result = _context.students.SingleOrDefault(x => x.id.Equals(id));
            if(result != null)
            {
                result.StudentFirstName = student.StudentFirstName;
                result.StudentLastName = student.StudentLastName;
                result.StudentLogin = student.StudentLogin;
                result.StudentPassword = student.StudentPassword;

                _context.SaveChanges();
            }
        }
    }
}
