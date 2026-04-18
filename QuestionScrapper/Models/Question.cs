namespace QuestionScrapper.Models
{
    public class Question
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Text { get; set; }

        public int Marks { get; set; }

        public int QuestionGroupId { get; set; }

        public QuestionGroup QuestionGroup { get; set; }
    }
}
