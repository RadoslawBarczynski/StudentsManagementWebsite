using Microsoft.EntityFrameworkCore;
using SchoolGradeManager.Models;
using SchoolGradeManager.Repositories;

namespace SchoolTestManager.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly StudentManagerContext _context;

        public TestRepository(StudentManagerContext context)
        {
            _context = context;
        }

        public Test Get(Guid id) => _context.tests.FirstOrDefault(x => x.id.Equals(id));


        public IQueryable<Test> GetAllActive() => _context.tests.Include("TestQuestions.question");


        public void Delete(Guid id)
        {
            var result = _context.tests.SingleOrDefault(x => x.id.Equals(id));
            if (result != null)
            {
                _context.tests.Remove(result);
                _context.SaveChanges();
            }
        }

        public void Update(Guid id, Test Test)
        {
            var result = _context.tests.FirstOrDefault(x => x.id.Equals(id));
            if (result != null)
            {
                result.TestName = Test.TestName;

                _context.SaveChanges();
            }
        }
    }
}
