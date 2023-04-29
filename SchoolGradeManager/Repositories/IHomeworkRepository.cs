using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public interface IHomeworkRepository
    {
        Homework Get(Guid id);
        IQueryable<Homework> GetAllActive();
        void Add(Homework student);
        void Update(Guid id, Homework homework);
        void Delete(Guid id);
    }
}
