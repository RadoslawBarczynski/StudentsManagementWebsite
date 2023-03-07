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

        public GradeRepository(StudentManagerContext context)
        {
            _context = context;           
        }

        public Grade Get(Guid id) => _context.grades.FirstOrDefault(x => x.GradeId.Equals(id));


        public IQueryable<Grade> GetAllActive() => _context.grades.Include("student");


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
