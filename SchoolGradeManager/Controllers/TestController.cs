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
        public ActionResult Index(int page = 1, int pageSize = 7)
        {
            var tests = _testRepository.GetAllActive();

            int totalCount = tests.Count();
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var paginatedStudents = tests.Skip((page - 1) * pageSize).Take(pageSize);

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalCount = totalCount;

            return View(paginatedStudents);
        }

        // GET: QuestionController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_testRepository.ShowQuestions(id));
        }

        // GET: QuestionController/Create
        public ActionResult Create()
        {
            return View(new Test());
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Test test)
        {
            _testRepository.Add(test);

            return RedirectToAction(nameof(Index));
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

        public ActionResult AddQuestions(Guid id)
        {
            return View(_testRepository.AddQuestions(id));
        }

        [HttpPost]
        public ActionResult AddQuestions(Guid id, List<Guid> Questions)
        {
            _testRepository.UpdateQuestions(id, Questions);

            return RedirectToAction("Index");
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
