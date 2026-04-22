using QuestionScrapper.Models;
using System.Runtime.InteropServices.Java;

namespace QuestionScrapper.Services
{
    public class AnswerAnalyzerService
    {

        public int EvaluateAnswers(List<Question> questions, List<StudentAnswer> answers)
        {
            var summark<int>= new summark<int> = 0;
            for (int i = 0; i < questions.Count; i++) { }
            var questionembed = GetEmbedding(questions[i]);
            var answersembed = GetEmbedding(answers[i]);
            similarity = cosine(questionembed, answersembed);
            if similarity > 0.75{
                obtainedmark = 5;
            }
            else if similarity > .5{
                obtainedmark = 3;
            }
            else
            {
                obtainedmark = 0;
            }
            summark = sumark.Add(obtainedemark);
            return 0;
        }
        public int GetEmbedding(Question embed) { }
        public int cosine(int a, int b) { }
    }


}
