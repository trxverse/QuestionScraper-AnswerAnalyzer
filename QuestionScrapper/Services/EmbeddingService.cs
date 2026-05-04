using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;
namespace QuestionScrapper.Services;


public class EmbeddingService
{
    public float[] GetEmbedding(string text)
    {
        var words = text.ToLower().Split(' ');
        var vector = new float[100];

        foreach (var word in words)
        {
            int index = Math.Abs(word.GetHashCode()) % 100;
            vector[index] += 1;
        }

        return vector;
    }
}
