using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolGradeManager.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SchoolGradeManager.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {

        private readonly StudentManagerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeworkRepository(StudentManagerContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IQueryable<Homework> GetAllActive()
        {
            string teacherIdFromSession = _httpContextAccessor.HttpContext.Session.GetString("TeacherId");

            return _context.homeworks
                .Where(homework => homework.teacherid.ToString() == teacherIdFromSession);
        }
        public Homework Get(Guid id)
        {
            Homework homework = _context.homeworks.SingleOrDefault(x => x.id.Equals(id));
            //student.grade = _context.grades.SingleOrDefault(y => y.GradeId.Equals(student.GradeId));
            return homework;
        }

        public void Add(Homework homework)
        {
            string teacherIdFromSession = _httpContextAccessor.HttpContext.Session.GetString("TeacherId");

            if (Guid.TryParse(teacherIdFromSession, out Guid teacherIdGuid))
            {
                Guid myuuid = Guid.NewGuid();
                homework.id = myuuid;
                homework.teacherid = teacherIdGuid;
                _context.homeworks.Add(homework);

                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Missing guid");
            }
        }

        public void Delete(Guid id)
        {
            var result = _context.homeworks.SingleOrDefault(x => x.id.Equals(id));
            if (result != null)
            {
                _context.homeworks.Remove(result);
                _context.SaveChanges();
            }
        }      

        public void Update(Guid id, Homework homework)
        {
            var result = _context.homeworks.SingleOrDefault(x => x.id.Equals(id));
            if (result != null)
            {
                result.ScoreToGet = homework.ScoreToGet;
                result.GameNumber = homework.GameNumber;
                result.isActive = homework.isActive;

                _context.SaveChanges();
            }
        }
    }
}
