using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SchoolGradeManager.Models;
using System.Data;

namespace SchoolGradeManager.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly StudentManagerContext _context;

        public GradeRepository(StudentManagerContext context)
        {
            _context = context;
            foreach (Grade grade in _context.grades)
            {
                grade.student = _context.students.SingleOrDefault(z => z.GradeId == grade.GradeId);
            }            
        }

        public Grade Get(int id) => _context.grades.FirstOrDefault(x => x.GradeId == id);


        public IQueryable<Grade> GetAllActive() => _context.grades;


        public void Delete(int id)
        {
            var result = _context.grades.SingleOrDefault(x => x.GradeId == id);
            if (result != null)
            {
                _context.grades.Remove(result);
                _context.SaveChanges();
            }
        }

        public void Update(int id, Grade grade)
        {
            var result = _context.grades.FirstOrDefault(x => x.GradeId == id);
            if(result != null)
            {
                result.G_Score = grade.G_Score;

                _context.SaveChanges();
            }
        }

    }
}
