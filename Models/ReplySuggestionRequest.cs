namespace AiEmailAssistant.Models;

public class ReplySuggestionRequest
{
    public string IncomingEmail { get; set; } = string.Empty;
    public string Tone { get; set; } = "formal";
}