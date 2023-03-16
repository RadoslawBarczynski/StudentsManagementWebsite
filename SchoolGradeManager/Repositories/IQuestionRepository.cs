using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public interface IQuestionRepository
    {
        Question Get(Guid id);
        IQueryable<Question> GetAllActive();
        void Add(Question question);
        void Update(Guid id, Question question);
        void Delete(Guid id);
    }
}
