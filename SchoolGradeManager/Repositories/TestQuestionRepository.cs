using Microsoft.EntityFrameworkCore;
using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public class TestQuestionRepository : ITestQuestionRepository
    {
        private readonly StudentManagerContext _context;

        public TestQuestionRepository(StudentManagerContext context)
        {
            _context = context;
        }
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public TestQuestion Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TestQuestion> GetAllActive() => _context.TestQuestions.Include("question").Include("test");

        public void Update(Guid id, TestQuestion testQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
