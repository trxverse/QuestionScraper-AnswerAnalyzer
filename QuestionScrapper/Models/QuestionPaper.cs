using Microsoft.AspNetCore.Http.HttpResults;

namespace QuestionScrapper.Models
{
    public class QuestionPaper
    {
        public int Id { get; set; }

        public string ExtractedText { get; set; }

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        //public List<QuestionGroup> Groups { get; set; } = new();
    }
}