namespace QuestionScrapper.Models
{
    public class QuestionGroup
    {
        public int Id { get; set; }

        public string GroupName { get; set; }  

        public int TotalQuestions { get; set; }

        public int MarksPerQuestion { get; set; }

        public int QuestionPaperId { get; set; }

        public QuestionPaper QuestionPaper { get; set; }

        public List<Question> Questions { get; set; }
    }
}
