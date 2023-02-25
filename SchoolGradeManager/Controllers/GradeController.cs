using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SchoolGradeManager.Models;
using SchoolGradeManager.Repositories;
using System.Data;

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

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_gradeRepository.Get(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Grade grade)
        {
            _gradeRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        // GET: GradeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_gradeRepository.Get(id));
        }

        // POST: GradeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Grade grade)
        {
            _gradeRepository.Update(id, grade);

            return RedirectToAction(nameof(Index));
        }
    }
}
