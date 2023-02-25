using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public interface IGradeRepository
    {
        Grade Get(int id);
        IQueryable<Grade> GetAllActive();


        void Delete(int id);
        void Update(int id, Grade grade);
    }
}
