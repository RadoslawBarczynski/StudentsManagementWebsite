using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public interface IGradeRepository
    {
        Grade Get(int id);
        IQueryable<Grade> GetAllActive();
        void Add(Grade grade);
        void Update(int id, Grade grade);
        void Delete(int id);
    }
}
