namespace AiEmailAssistant.Models;
public class OllamaRequest
{
    public string Model { get; set; } = "gemma3";
    public string Prompt { get; set; } = string.Empty;
    public bool Stream { get; set; } = false;
}