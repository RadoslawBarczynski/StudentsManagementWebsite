using MessagePack.Resolvers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolGradeManager.Models;
using SchoolGradeManager.Repositories;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;

namespace SchoolGradeManager.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View(_studentRepository.GetAllActive());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(_studentRepository.Get(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View(new Student());
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            _studentRepository.Add(student);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_studentRepository.Get(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            _studentRepository.Update(id, student);

            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_studentRepository.Get(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student student)
        {
            _studentRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
