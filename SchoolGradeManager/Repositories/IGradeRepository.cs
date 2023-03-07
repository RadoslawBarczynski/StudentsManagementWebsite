using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public interface IGradeRepository
    {
        Grade Get(Guid id);
        IQueryable<Grade> GetAllActive();

        void Delete(Guid id);
        void Update(Guid id, Grade grade);
    }
}
