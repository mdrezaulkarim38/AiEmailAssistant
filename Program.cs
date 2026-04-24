using AiEmailAssistant.Models;
using AiEmailAssistant.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<OllamaService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:11434");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Ai Email Assistant API is running.");

app.MapPost("/draft", async (DraftEmailRequest request, OllamaService ollama) =>
{
    var prompt = $"""
                  You are an email writing assistant.

                  Generate a professional email draft.

                  Recipient: {request.Recipient}
                  Purpose: {request.Purpose}
                  Context: {request.Context}
                  Tone: {request.Tone}

                  Return:
                  Subject:
                  Body:
                  """;
    var result = await ollama.GenerateAsync(prompt);
    return Results.Ok(result);
});

app.MapPost("/tone", async (ToneChangeRequest request, OllamaService ollama) =>
{
    var prompt = $"""
                  Rewrite the following email in a {request.TargetTone} tone.
                  Keep the meaning the same.

                  Email:
                  {request.EmailText}
                  """;
    var result = await ollama.GenerateAsync(prompt);
    return Results.Ok(new { output = result });
});

app.MapPost("/reply-suggestion", async (ReplySuggestionRequest request, OllamaService ollama) =>
{
    var prompt = $"""
                  You are an email reply assistant.

                  Read the incoming email and generate 3 reply suggestions in {request.Tone} tone.

                  Incoming email:
                  {request.IncomingEmail}
                  """;
    var result = await ollama.GenerateAsync(prompt);
    return Results.Ok(new { output = result });
});
app.Run();