using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolGradeManager.Repositories;

namespace SchoolGradeManager.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeController(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        // GET: GradeController
        public ActionResult Index()
        {
            return View(_gradeRepository.GetAllActive());
        }

        // GET: GradeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GradeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GradeController/Create
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

        // GET: GradeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GradeController/Edit/5
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

        // GET: GradeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GradeController/Delete/5
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
