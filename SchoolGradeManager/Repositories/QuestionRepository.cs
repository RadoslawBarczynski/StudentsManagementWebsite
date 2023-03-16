using Microsoft.EntityFrameworkCore;
using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly StudentManagerContext _context;

        public QuestionRepository(StudentManagerContext context)
        {
            _context = context;
        }

        public Question Get(Guid id)
        {
            Question question = _context.questions.SingleOrDefault(x => x.id.Equals(id));
            return question;
        }

        public IQueryable<Question> GetAllActive() => _context.questions;

        public void Add(Question question)
        {
            Guid myuuid = Guid.NewGuid();
            question.id = myuuid;
            _context.questions.Add(question);


            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var result = _context.questions.SingleOrDefault(x => x.id.Equals(id));
            if (result != null)
            {
                _context.questions.Remove(result);
                _context.SaveChanges();
            }
        }

        public void Update(Guid id, Question question)
        {
            var result = _context.questions.SingleOrDefault(x => x.id.Equals(id));
            if (result != null)
            {
                result.operation = question.operation;
                result.answer1 = question.answer1;
                result.answer2 = question.answer2;
                result.answer3 = question.answer3;

                _context.SaveChanges();
            }
        }
    }
}
