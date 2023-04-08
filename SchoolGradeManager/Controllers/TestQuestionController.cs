using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolGradeManager.Repositories;

namespace SchoolGradeManager.Controllers
{
    public class TestQuestionController : Controller
    {
        private readonly ITestQuestionRepository _testQuestionRepository;

        public TestQuestionController(ITestQuestionRepository testQuestionRepository)
        {
            _testQuestionRepository = testQuestionRepository;
        }
        // GET: TestQuestionController
        public ActionResult Index()
        {
            return View(_testQuestionRepository.GetAllActive());
        }

        // GET: TestQuestionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestQuestionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestQuestionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestQuestionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestQuestionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestQuestionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestQuestionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
