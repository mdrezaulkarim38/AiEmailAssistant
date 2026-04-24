using AiEmailAssistant.Models;

namespace AiEmailAssistant.Services;

public class OllamaService
{
    private readonly HttpClient _httpClient;

    public OllamaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GenerateAsync(string prompt, string model = "gemma3")
    {
        var request = new OllamaRequest
        {
            Model = model,
            Prompt = prompt,
            Stream = false
        };
        var response = await _httpClient.PostAsJsonAsync("/api/generate", request);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<OllamaResponse>();
        return result?.Response ?? "No response from model.";
    }
}