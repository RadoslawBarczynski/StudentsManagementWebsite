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
                string[] DashboardCount = new string[3];
                SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=StudentManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true;");
                con.Open();
                //SqlCommand cmd = new SqlCommand("select count(Math) as MathB,(select count(Math) from Grade where Math = 'A') as MathA from Grade where Math = 'B'");
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select Sum(case when Math = 'A' then 1 else 0 END +\r\n\t\t\tcase when English = 'A' then 1 else 0 END +\r\n\t\t\tcase when Biology = 'A' then 1 else 0 END +\r\n\t\t\tcase when History = 'A' then 1 else 0 END +\r\n\t\t\tcase when Geography = 'A' then 1 else 0 END +\r\n\t\t\tcase when PE = 'A' then 1 else 0 END) as A from Grade\r\n\t\t\tUNION\r\n\t\t\tselect Sum(case when Math = 'B' then 1 else 0 END +\r\n\t\t\tcase when English = 'B' then 1 else 0 END +\r\n\t\t\tcase when Biology = 'B' then 1 else 0 END +\r\n\t\t\tcase when History = 'B' then 1 else 0 END +\r\n\t\t\tcase when Geography = 'B' then 1 else 0 END +\r\n\t\t\tcase when PE = 'B' then 1 else 0 END) as B from Grade\r\n\t\t\tUNION\r\n\t\t\tselect Sum(case when Math = 'C' then 1 else 0 END +\r\n\t\t\tcase when English = 'C' then 1 else 0 END +\r\n\t\t\tcase when Biology = 'C' then 1 else 0 END +\r\n\t\t\tcase when History = 'C' then 1 else 0 END +\r\n\t\t\tcase when Geography = 'C' then 1 else 0 END +\r\n\t\t\tcase when PE = 'C' then 1 else 0 END) as C from Grade";
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter cmd1 = new SqlDataAdapter(cmd);
                cmd1.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    DashboardCount[0] = "0";
                    DashboardCount[1] = "0";
                    DashboardCount[2] = "0";
                }
                else
                {
                    DashboardCount[0] = dt.Rows[0]["A"].ToString();
                    DashboardCount[1] = dt.Rows[1]["A"].ToString();
                    DashboardCount[2] = dt.Rows[2]["A"].ToString();
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
