namespace AiEmailAssistant.Models;

public class DraftEmailRequest
{
    public string Purpose { get; set; } = string.Empty;
    public string Recipient { get; set; } = string.Empty;
    public string Context { get; set; } = string.Empty;
    public string Tone { get; set; } = "formal";
}