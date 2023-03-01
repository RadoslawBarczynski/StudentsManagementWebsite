using Microsoft.EntityFrameworkCore;
using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentManagerContext _context;
        public StudentRepository(StudentManagerContext context)
        {
            _context = context;
            foreach (Student student in _context.students)
            {
                student.grade = _context.grades.SingleOrDefault(z => z.GradeId == student.GradeId);
            }
        }
        public Student Get(int id)
        {
            Student student = _context.students.SingleOrDefault(x => x.Id == id);
            student.grade = _context.grades.SingleOrDefault(y => y.GradeId == student.GradeId);
            return student;
        }


        public IQueryable<Student> GetAllActive() => _context.students;


        public void Add(Student student)
        {
            _context.students.Add(student);
            //basic grade template
            Grade grade = new Grade();
            grade.G_Score = 0;
            grade.student = student;
            student.GradeId = grade.GradeId;

            _context.grades.Add(grade);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var result = _context.students.SingleOrDefault(x => x.Id == id);
            if(result != null)
            {
                _context.grades.Remove(result.grade);
                _context.students.Remove(result);
                _context.SaveChanges();
            }
        }

        public void Update(int id, Student student)
        {
            var result = _context.students.SingleOrDefault(x => x.Id == id);
            if(result != null)
            {
                result.StudentFirstName = student.StudentFirstName;
                result.StudentLastName = student.StudentLastName;
                result.StudentEmail = student.StudentEmail;

                _context.SaveChanges();
            }
        }
    }
}
