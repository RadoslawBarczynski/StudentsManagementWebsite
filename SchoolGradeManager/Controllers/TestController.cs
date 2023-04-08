using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolGradeManager.Models;
using SchoolGradeManager.Repositories;

namespace SchoolGradeManager.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestRepository _testRepository;

        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        // GET: GradeController
        public ActionResult Index()
        {
            return View(_testRepository.GetAllActive());
        }

        // GET: QuestionController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_testRepository.Get(id));
        }

        // GET: QuestionController/Create
        public ActionResult Create()
        {
            return View(new Test());
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(_testRepository.Get(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, Test test)
        {
            _testRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        // GET: GradeController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(_testRepository.Get(id));
        }

        // POST: GradeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Test test)
        {
            _testRepository.Update(id, test);

            return RedirectToAction(nameof(Index));
        }
    }
}
