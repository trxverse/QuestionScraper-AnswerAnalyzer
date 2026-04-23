using System.Net.Http;
using System.Text;
using System.Text.Json;
namespace QuestionScrapper.Services;


public class EmbeddingService
{
private readonly HttpClient _client;

public EmbeddingService()
{
    _client = new HttpClient();
    //_client.DefaultRequestHeaders.Add("Authorization", "Bearer YOUR_HF_API_KEY");
}

public async Task<float[]> GetEmbedding(string text)
{
    var url = "https://api-inference.huggingface.co/pipeline/feature-extraction/sentence-transformers/all-MiniLM-L6-v2";

    var json = JsonSerializer.Serialize(text);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    var response = await _client.PostAsync(url, content);
    var result = await response.Content.ReadAsStringAsync();

    // parse response (list of floats)
    var embedding = JsonSerializer.Deserialize<float[]>(result);
        Console.WriteLine("embedservice" + embedding);
    return embedding ?? new float[0];
}
}
