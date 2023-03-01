using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SchoolGradeManager.Models;
using SchoolGradeManager.Repositories;
using System.Data;
using Microsoft.Extensions.Configuration;


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

        public ActionResult Details()
        {
            return View();
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

        public JsonResult DashBoardCount()
        {
            try
            {
                string[] DashboardCount = new string[2];
                SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=StudentManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true;");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select count(Score) as failed, (select count(Score) from Grade where Score > 45) as passed from Grade where Score < 46 ";
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter cmd1 = new SqlDataAdapter(cmd);
                cmd1.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    DashboardCount[0] = "0";
                    DashboardCount[1] = "0";
                }
                else
                {
                    DashboardCount[0] = dt.Rows[0]["passed"].ToString();
                    DashboardCount[1] = dt.Rows[0]["failed"].ToString();
                    Console.WriteLine(DashboardCount[0]);
                    Console.WriteLine(DashboardCount[1]);
                }

                return Json(DashboardCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
