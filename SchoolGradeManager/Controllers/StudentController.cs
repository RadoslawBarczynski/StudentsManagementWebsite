using MessagePack.Resolvers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolGradeManager.Models;

namespace SchoolGradeManager.Controllers
{
    public class StudentController : Controller
    {
        private static IList<Student> students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                StudentFirstName = "Radosław",
                StudentLastName = "Barczyński",
                StudentEmail = "radbar@utp.edu.pl"
            }
        };

        // GET: StudentController
        public ActionResult Index()
        {
            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            student.Id = students.Count + 1;
            students.Add(student);            
            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
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

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
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
