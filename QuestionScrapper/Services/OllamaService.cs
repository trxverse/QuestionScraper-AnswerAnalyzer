using System.Text;
using System.Text.Json;
namespace QuestionScrapper.Services;
public class OllamaService
{
    private readonly HttpClient _http;

    public OllamaService()
    {
        _http = new HttpClient();
    }

    public async Task<string> Evaluate(string question, string answer)
    {
        var prompt = $@"
You are an exam evaluator.

Question: {question}
Student Answer: {answer}

Give:
1. Score out of 5
2. Short feedback

Format:
Score: X
";

        var payload = new
        {
            model = "mistral",
            prompt = prompt,
            stream = false
        };

        var json = JsonSerializer.Serialize(payload);

        var response = await _http.PostAsync(
            "http://localhost:11434/api/generate",
            new StringContent(json, Encoding.UTF8, "application/json")
        );

        var doc = JsonDocument.Parse(json);
        var result = doc.RootElement.GetProperty("response").GetString();
        Console.WriteLine(result);

        return result;
    }
}