using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public interface ITestQuestionRepository
    {
        TestQuestion Get(Guid id);
        IQueryable<TestQuestion> GetAllActive();

        void Delete(Guid id);
        void Update(Guid id, TestQuestion testQuestion);
    }
}
