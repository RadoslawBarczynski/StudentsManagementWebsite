using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public interface ITestRepository
    {
        Test Get(Guid id);
        IQueryable<Test> GetAllActive();

        void Delete(Guid id);
        void Update(Guid id, Test test);
    }
}
