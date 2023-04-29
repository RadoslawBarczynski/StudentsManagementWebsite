using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolGradeManager.Models;
using SchoolGradeManager.Repositories;

namespace SchoolGradeManager.Controllers
{
    public class HomeworkController : Controller
    {
        private readonly IHomeworkRepository _homeworkRepository;

        public HomeworkController(IHomeworkRepository homeworkRepository)
        {
            _homeworkRepository = homeworkRepository;
        }
        // GET: HomeworkController
        public ActionResult Index()
        {
            return View(_homeworkRepository.GetAllActive());
        }

        // GET: HomeworkController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_homeworkRepository.Get(id));
        }

        // GET: HomeworkController/Create
        public ActionResult Create()
        {
            return View(new Homework());
        }

        // POST: HomeworkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Homework homework)
        {
            _homeworkRepository.Add(homework);

            return RedirectToAction(nameof(Index));
        }

        // GET: HomeworkController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(_homeworkRepository.Get(id));
        }

        // POST: HomeworkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Homework homework)
        {
            _homeworkRepository.Update(id, homework);

            return RedirectToAction(nameof(Index));
        }

        // GET: HomeworkController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(_homeworkRepository.Get(id));
        }

        // POST: HomeworkController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, Homework homework)
        {
            _homeworkRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
