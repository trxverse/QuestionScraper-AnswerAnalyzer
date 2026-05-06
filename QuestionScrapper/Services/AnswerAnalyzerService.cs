using QuestionScrapper.Models;
using System.Runtime.InteropServices.Java;

namespace QuestionScrapper.Services
{
    public class AnswerAnalyzerService
    {
        private readonly OllamaService _ollama;
        int result;
        public AnswerAnalyzerService(OllamaService ollama)
        {
            _ollama = ollama;
        }

        public async Task<int> EvaluateAnswers(List<Question> questions, List<StudentAnswer> answers)
        {
            int totalMarks = 0;
            Console.WriteLine("questionno" + questions.Count);
            Console.WriteLine("answer no " + answers.Count);
            for (int i = 0; i < questions.Count; i++)
            {
                var questionText = questions[i].Text;
                var answerText = answers[i].AnswerText;

                var response = await _ollama.Evaluate(questionText, answerText);
                 result = Int32.Parse(response);

                Console.WriteLine($"{response}");
                //        var similarity = cosine(questionembed, answersembed);
                //        Console.WriteLine("similariyt answeranz out"+similarity.ToString());
                //        int obtainedMark;
                //        if (similarity > 0.75){
                //            obtainedMark = 5;
                //        }
                //        else if (similarity > .5){
                //            obtainedMark = 3;
                //        }
                //        else
                //        {
                //            obtainedMark = 0;
                //        }
                //        Console.WriteLine("obotalmarks" + obtainedMark);
                //        totalMarks += obtainedMark;
                //    }
                //    Console.WriteLine("totalmarks"+totalMarks);
                //    return totalMarks;

                //}
                //public double cosine(float []a, float []b)
                //{

                //    double dot = 0, magA = 0, magB = 0;
                //    for (int i = 0; i < a.Length; i++)
                //    {
                //        dot += a[i] * b[i];
                //        magA += a[i] * a[i];
                //        magB += b[i] * b[i];
                //    }

                //    return dot / (Math.Sqrt(magA) * Math.Sqrt(magB));
                //}
                
            }

            return result;
        }
    }
}



