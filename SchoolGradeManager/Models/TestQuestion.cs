using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolGradeManager.Models
{
    [Table("TestQuestions")]
    public class TestQuestion
    {
        public Guid id { get; set; }

        public Guid TestId { get; set; }
        public Test test { get; set; }  
        public Guid QuestionId { get; set; }
        public Question question { get; set; }  

    }
}
