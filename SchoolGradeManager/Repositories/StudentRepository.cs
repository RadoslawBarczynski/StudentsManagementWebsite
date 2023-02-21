using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentManagerContext _context;
        public StudentRepository(StudentManagerContext context)
        {
            _context = context;
        }
        public Student Get(int id) => _context.students.SingleOrDefault(x => x.Id == id);


        public IQueryable<Student> GetAllActive() => _context.students;


        public void Add(Student student)
        {
            _context.students.Add(student);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var result = _context.students.SingleOrDefault(x => x.Id == id);
            if(result != null)
            {
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
