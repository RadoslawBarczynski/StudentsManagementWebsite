using Microsoft.EntityFrameworkCore;
using SchoolGradeManager.Models;

namespace SchoolGradeManager.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {

        private readonly StudentManagerContext _context;
        public HomeworkRepository(StudentManagerContext context)
        {
            _context = context;
        }

        public IQueryable<Homework> GetAllActive() => _context.homeworks;
        public Homework Get(Guid id)
        {
            Homework homework = _context.homeworks.SingleOrDefault(x => x.id.Equals(id));
            //student.grade = _context.grades.SingleOrDefault(y => y.GradeId.Equals(student.GradeId));
            return homework;
        }

        public void Add(Homework homework)
        {
            Guid myuuid = Guid.NewGuid();
            homework.id = myuuid;
            _context.homeworks.Add(homework);

            _context.SaveChanges();
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
