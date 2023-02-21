using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public interface IStudentRepository
    {
        Student Get(int id);
        IQueryable<Student> GetAllActive();
        void Add(Student student);
        void Update(int id, Student student);
        void Delete(int id);
    }
}
