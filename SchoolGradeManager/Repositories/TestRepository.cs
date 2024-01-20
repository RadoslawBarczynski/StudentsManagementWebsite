using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolGradeManager.Models;
using SchoolGradeManager.Repositories;

namespace SchoolTestManager.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly StudentManagerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TestRepository(StudentManagerContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public Test Get(Guid id) => _context.tests.FirstOrDefault(x => x.id.Equals(id));


        public IQueryable<Test> GetAllActive()
        {
            string teacherIdFromSession = _httpContextAccessor.HttpContext.Session.GetString("TeacherId");

            return _context.tests
                .Include("TestQuestions.question")
                .Where(student => student.teacherId.ToString() == teacherIdFromSession);
        } //=> _context.tests.Include("TestQuestions.question");

        public AddQuestionsToTest ShowQuestions(Guid id)
        {
            var test = _context.tests.FirstOrDefault(x => x.id.Equals(id));
            List<Question> questiones = new List<Question>();

            foreach(var item in _context.TestQuestions.Include("question"))
            {
                if(item.TestId == id)
                {
                    questiones.Add(item.question);
                }
            }

            var addQuestionsToTest = new AddQuestionsToTest
            {
                questionsInTest = questiones,
                testForQuestions = test
            };
            return addQuestionsToTest;

        }

        public AddQuestionsToTest AddQuestions(Guid id)
        {
            var test = _context.tests.FirstOrDefault(x => x.id.Equals(id));

            var questions = _context.questions
    .Where(q => !_context.TestQuestions.Any(tq => tq.TestId.Equals(id) && tq.QuestionId.Equals(q.id)))
    .ToList();

            var checkedQuestions = _context.questions
    .Where(q => _context.TestQuestions.Any(tq => tq.TestId.Equals(id) && tq.QuestionId.Equals(q.id)))
    .ToList();

            var addQuestionsToTest = new AddQuestionsToTest
            {
                questionsInTest = questions,
                questionsInTestChecked = checkedQuestions,
                testForQuestions = test
            };
            return addQuestionsToTest;
        }

        public void UpdateQuestions(Guid id, List<Guid> Questions)
        {
            var test = _context.tests.FirstOrDefault(t => t.id == id);
            System.Diagnostics.Debug.WriteLine("=====================================");
            System.Diagnostics.Debug.WriteLine(Questions.Count);
            System.Diagnostics.Debug.WriteLine("=====================================");

            var existingTestQuestions = _context.TestQuestions
    .Where(tq => tq.test == test && !Questions.Contains(tq.question.id))
    .ToList();

            foreach (var existingTestQuestion in existingTestQuestions)
            {
                _context.TestQuestions.Remove(existingTestQuestion);
            }

            _context.SaveChanges();

            foreach (var questionId in Questions)
            {
                var question = _context.questions.FirstOrDefault(q => q.id == questionId);

                if (question != null)
                {
                    bool connectionExists = _context.TestQuestions.Any(tq => tq.test == test && tq.question == question);

                    if (!connectionExists)
                    {
                        Guid myuuid = Guid.NewGuid();
                        TestQuestion testQuestion = new TestQuestion();
                        testQuestion.id = myuuid;
                        testQuestion.test = test;
                        testQuestion.question = question;

                        _context.TestQuestions.Add(testQuestion);

                        _context.SaveChanges();
                    }
                }
            }
        }

        public void Add(Test test)
        {
            string teacherIdFromSession = _httpContextAccessor.HttpContext.Session.GetString("TeacherId");

            if (Guid.TryParse(teacherIdFromSession, out Guid teacherIdGuid))
            {
                Guid myuuid = Guid.NewGuid();
                test.id = myuuid;
                test.teacherId = teacherIdGuid;
                _context.tests.Add(test);

                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Missing guid");
            }
        }


        public void Delete(Guid id)
        {
            var result = _context.tests.SingleOrDefault(x => x.id.Equals(id));

            foreach (var item in _context.TestQuestions)
            {
                if(item.TestId == result.id)
                {
                    _context.TestQuestions.Remove(item);
                }           
            }
            _context.SaveChanges();
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
                result.isActive = Test.isActive;
                

                _context.SaveChanges();
            }
        }
    }
}
