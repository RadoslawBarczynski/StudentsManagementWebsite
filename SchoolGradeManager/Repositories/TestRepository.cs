using Microsoft.AspNetCore.Mvc;
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
            var questions = _context.questions.ToList();

            var addQuestionsToTest = new AddQuestionsToTest
            {
                questionsInTest = questions,
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

            foreach (var questionId in Questions)
            {
                var question = _context.questions.FirstOrDefault(q => q.id == questionId);

                if(question != null)
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

        public void Add(Test test)
        {
            Guid myuuid = Guid.NewGuid();
            test.id = myuuid;
            _context.tests.Add(test);

            _context.SaveChanges();
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
