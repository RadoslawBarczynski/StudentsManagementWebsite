using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public interface ITestRepository
    {
        Test Get(Guid id);
        IQueryable<Test> GetAllActive();

        AddQuestionsToTest ShowQuestions(Guid id);

        AddQuestionsToTest AddQuestions(Guid id);

        void UpdateQuestions(Guid id, List<Guid> Questions);

        void Add(Test test);

        void Delete(Guid id);
        void Update(Guid id, Test test);
    }
}
