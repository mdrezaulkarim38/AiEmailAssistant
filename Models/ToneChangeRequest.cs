namespace AiEmailAssistant.Models;

public class ToneChangeRequest
{
    public string EmailText { get; set; } = string.Empty;
    public string TargetTone { get; set; } = "formal";
}