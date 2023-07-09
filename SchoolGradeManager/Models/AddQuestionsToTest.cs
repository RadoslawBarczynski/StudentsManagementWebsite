namespace SchoolGradeManager.Models
{
    public class AddQuestionsToTest
    {
        public List<Question> questionsInTest { get; set; }

        public List<Question> questionsInTestChecked { get; set; }
        public Test testForQuestions { get; set; }
    }
}
