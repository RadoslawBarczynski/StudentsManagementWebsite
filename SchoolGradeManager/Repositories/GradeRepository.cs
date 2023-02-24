using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly StudentManagerContext _context;
        public GradeRepository(StudentManagerContext context)
        {
            _context = context;
        }

        public void Add(Grade grade)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Grade Get(int id) => _context.grades.FirstOrDefault(x => x.GradeId == id);


        public IQueryable<Grade> GetAllActive() => _context.grades;


        public void Update(int id, Grade grade)
        {
            throw new NotImplementedException();
        }

    }
}
