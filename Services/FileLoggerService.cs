namespace AiEmailAssistant.Services;

public class FileLoggerService
{
    private readonly string _logDirectory;

    public FileLoggerService()
    {
        _logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "logs");
        if (!Directory.Exists(_logDirectory))
        {
            Directory.CreateDirectory(_logDirectory);
        }
    }

    public async Task LogAsync(string endpoint, object request, string response)
    {
        var fileName = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss-fff}.txt";
        var filePath = Path.Combine(_logDirectory, fileName);
        var logContent = $"""
                          ===== AI EMAIL ASSISTANT LOG =====
                          Time: {DateTime.Now}

                          Endpoint: {endpoint}

                          ----- Client Request -----
                          {System.Text.Json.JsonSerializer.Serialize(request, new System.Text.Json.JsonSerializerOptions
                          {
                              WriteIndented = true
                          })}

                          ----- AI Response -----
                          {response}

                          =================================
                          """;

        await File.WriteAllTextAsync(filePath, logContent);
    }
}