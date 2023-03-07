using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public interface IStudentRepository
    {
        Student Get(Guid id);
        IQueryable<Student> GetAllActive();
        void Add(Student student);
        void Update(Guid id, Student student);
        void Delete(Guid id);
    }
}
