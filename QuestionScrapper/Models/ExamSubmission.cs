namespace QuestionScrapper.Models
{
    public class ExamSubmission
    {
        public int Id { get; set; }
        public List<StudentAnswer> Answers { get; set; }
        public int TotalMarks { get; set; }
    }
}
