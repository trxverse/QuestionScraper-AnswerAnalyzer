
using QuestionScrapper.Models;
using System.Text.RegularExpressions;

namespace QuestionScrapper.Services;


public class QuestionParser
{
    //public  QuestionPaper Parse(string text)
    //{
    //    var paper = new QuestionPaper
    //    {
    //        Groups = new List<QuestionGroup>()
    //    };
    //    // Detect Group B section
    //    var groupBPattern = @"Group\s*B[\s\S]*?\[6\s*X\s*5\s*=\s*30\]([\s\S]*?)Group\s*C";
    //    var groupCPattern = @"Group\s*C[\s\S]*?\[2\s*X\s*10\s*=\s*20\]([\s\S]*)";

    //    var groupBMatch = Regex.Match(text, groupBPattern, RegexOptions.IgnoreCase);
    //    var groupCMatch = Regex.Match(text, groupCPattern, RegexOptions.IgnoreCase);

    //    if (groupBMatch.Success)
    //    {
    //        string groupBText = groupBMatch.Groups[1].Value;
    //        var groupB = new QuestionGroup
    //        {
    //            GroupName = "Group B",
    //            TotalQuestions = 7,
    //            MarksPerQuestion = 5,
    //            Questions = ExtractQuestions(groupBText, 5)
    //        };

    //        paper.Groups.Add(groupB);
    //    }

    //    if (groupCMatch.Success)
    //    {
    //        string groupCText = groupCMatch.Groups[1].Value;

    //        var groupC = new QuestionGroup
    //        {
    //            GroupName = "Group C",
    //            TotalQuestions = 3,
    //            MarksPerQuestion = 10,
    //            Questions = ExtractQuestions(groupCText, 10)
    //        };
    //        paper.Groups.Add(groupC);

    //    }

    //    return paper;
    //}

    //private List<Question> ExtractQuestions(string text, int marks)
    //{
    //    var questions = new List<Question>();

    //    // Regex pattern that detects question numbers like "1.", "2.", "3."
    //    var pattern = @"(?=\d+\.)";

    //    var parts = Regex.Split(text, pattern)
    //                     .Where(p => !string.IsNullOrWhiteSpace(p))
    //                     .ToList();

    //    foreach (var part in parts)
    //    {
    //        var match = Regex.Match(part, @"(\d+)\.\s*(.*)", RegexOptions.Singleline);

    //        if (match.Success)
    //        {
    //            int qNumber = int.Parse(match.Groups[1].Value);
    //            string qText = match.Groups[2].Value.Trim();

    //            questions.Add(new Question
    //            {
    //                Number = int.Parse(match.Groups[1].Value),
    //                Text = match.Groups[2].Value.Trim(),
    //                Marks = marks
    //            });
    //        }
    //    }

    //    return questions;
    //}
}
