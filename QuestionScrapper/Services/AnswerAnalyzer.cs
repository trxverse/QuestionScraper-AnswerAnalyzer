//using MathNet.Numerics.LinearAlgebra;
//using QuestionPaperAnalyzer.Models;
//using QuestionScrapper.Models;
//using System.Numerics;

//namespace QuestionScrapper.Services
//{
//    public class AnalyzerService
//    {
//        private readonly IEmbeddingService _embeddingService; // Could call Python API or ONNX

//        public AnalyzerService(IEmbeddingService embeddingService)
//        {
//            _embeddingService = embeddingService;
//        }

//        public async Task<double> EvaluateAnswersAsync(List<StudentAnswer> answers)
//        {
//            double totalMarks = 0;

//            foreach (var ans in answers)
//            {
//                // Get question text from DB or in-memory
//                var questionText = await GetQuestionTextById(ans.QuestionId);

//                var vector1 = await _embeddingService.GetEmbeddingAsync(questionText);
//                var vector2 = await _embeddingService.GetEmbeddingAsync(ans.AnswerText);

//                double similarity = CosineSimilarity(vector1, vector2);

//                // Apply marking logic
//                double marks = similarity >= 0.85 ? 1.0 :
//                               similarity >= 0.65 ? 0.8 :
//                               similarity >= 0.45 ? 0.5 : 0;

//                ans.ObtainedMarks = marks; // If question marks != 1, multiply by question.Marks
//                totalMarks += marks;
//            }

//            return totalMarks;
//        }

//        private Task<string> GetQuestionTextById(int questionId)
//        {
//            // Fetch question text from DB or parser cache
//            throw new NotImplementedException();
//        }

//        private double CosineSimilarity(Vector<double> vec1, Vector<double> vec2)
//        {
//            return vec1.DotProduct(vec2) / (vec1.L2Norm() * vec2.L2Norm());
//        }
//    }
//}