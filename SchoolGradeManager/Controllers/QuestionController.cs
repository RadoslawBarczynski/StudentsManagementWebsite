using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolGradeManager.Models;
using SchoolGradeManager.Repositories;

namespace SchoolGradeManager.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        // GET: QuestionController
        public ActionResult Index()
        {
            return View(_questionRepository.GetAllActive());
        }

        // GET: QuestionController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_questionRepository.Get(id));
        }

        // GET: QuestionController/Create
        public ActionResult Create()
        {
            return View(new Question());
        }

        // POST: QuestionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            _questionRepository.Add(question);

            return RedirectToAction(nameof(Index));
        }

        // GET: QuestionController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(_questionRepository.Get(id));
        }

        // POST: QuestionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Question question)
        {
            _questionRepository.Update(id, question);

            return RedirectToAction(nameof(Index));

        }

        // GET: QuestionController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(_questionRepository.Get(id));
        }

        // POST: QuestionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, Question question)
        {
            _questionRepository.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
