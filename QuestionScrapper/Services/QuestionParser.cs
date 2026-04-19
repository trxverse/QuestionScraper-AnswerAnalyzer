
using QuestionScrapper.Models;
using System.Text.RegularExpressions;

namespace QuestionScrapper.Services;


public class QuestionParser
{
    public List<Question> Parse(string text)
    {
        var questions = new List<Question>();
        var matches = Regex.Matches(text, @"\d+\.\s*(.*)")
        int num = 1;
        foreach (Match match in matches) {
            questions.Add(new Question
            {
                Id = num,
                Text = match.Groups[1].Value
            });
            num++;
        }
        return questions;
    }

}
