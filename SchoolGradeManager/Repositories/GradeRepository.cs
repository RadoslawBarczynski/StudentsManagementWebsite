using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolGradeManager.Models;
using System.Data;

namespace SchoolGradeManager.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly StudentManagerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GradeRepository(StudentManagerContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public Grade Get(Guid id) => _context.grades.FirstOrDefault(x => x.GradeId.Equals(id));


        public IQueryable<Grade> GetAllActive()
        {
            string teacherIdFromSession = _httpContextAccessor.HttpContext.Session.GetString("TeacherId");

                return _context.grades
                .Include("student")
                .Where(grade => grade.student.TeacherId.ToString() == teacherIdFromSession);
        }


        public void Delete(Guid id)
        {
            var result = _context.grades.SingleOrDefault(x => x.GradeId.Equals(id));
            if (result != null)
            {
                _context.grades.Remove(result);
                _context.SaveChanges();
            }
        }

        public void Update(Guid id, Grade grade)
        {
            var result = _context.grades.FirstOrDefault(x => x.GradeId.Equals(id));
            if(result != null)
            {
                result.G_Score = grade.G_Score;

                _context.SaveChanges();
            }
        }

    }
}
