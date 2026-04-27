#  AI Email Assistant API

An AI-powered email assistant built with **ASP.NET Core** and **Ollama (Local LLM)**.
This API generates email drafts, rewrites tone, and suggests replies using a locally running language model.

---

##  Features

* ✉ Generate email drafts from structured input
*  Rewrite email tone (formal, casual, polite, etc.)
*  Suggest replies for incoming emails
*  Runs on **local LLM (Ollama)** — no external API required
*  Logs all requests and responses to `.txt` files

---

##  Tech Stack

* **Backend:** C# (.NET 8, ASP.NET Core Minimal API)
* **AI Model:** Ollama (Gemma / Qwen / other local LLMs)
* **API Docs:** Swagger (OpenAPI)
* **Logging:** File-based logging system

---

##  Setup & Installation

### 1. Clone the repository

```bash
git clone https://github.com/mdrezaulkarim38/AiEmailAssistant.git
cd AiEmailAssistant
```

---

### 2. Install Ollama

Download from: https://ollama.com

Run a model:

```bash
ollama run gemma3
```

---

### 3. Run the API

```bash
dotnet run
```

---

### 4. Open Swagger UI

```
http://localhost:xxxx/swagger
```

---

##  API Endpoints

###  POST `/draft`

Generate an email draft

```json
{
  "purpose": "request a meeting",
  "recipient": "manager",
  "context": "discuss project blockers",
  "tone": "formal"
}
```

---

###  POST `/tone`

Rewrite email tone

```json
{
  "emailText": "Hey, send me the file ASAP.",
  "targetTone": "formal"
}
```

---

###  POST `/reply-suggestion`

Generate reply suggestions

```json
{
  "incomingEmail": "Can you send the report by tonight?",
  "tone": "professional"
}
```

---

##  Logging System

* All requests and AI responses are saved in `/Logs` folder
* Each request creates a timestamped `.txt` file
* Useful for debugging and auditing AI outputs

---

##  What I Learned

* Working with **Local LLMs (Ollama)**
* Prompt Engineering for structured outputs
* Building AI-powered APIs with ASP.NET Core
* Handling AI response validation and formatting
* Designing scalable backend architecture

---

##  Sample Output

```
Subject: Meeting Request

Dear Manager,

I would like to request a meeting to discuss current project blockers...
```

---

##  Future Improvements

* Structured JSON responses
* Frontend UI (React / Blazor)
* Email templates & personalization
* Database integration
* RAG (Retrieval-Augmented Generation)

---

## 👤 Author

**Md Rezaul Karim**
GitHub: https://github.com/mdrezaulkarim38

---

## ⭐ If you like this project, give it a star!
