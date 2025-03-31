using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    private static readonly HttpClient client = new HttpClient();
    private const string apiKey = "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"; // Replace with your actual API key
    private const string apiUrl = "https://api.groq.com/openai/v1/chat/completions";
    private const string HistoryFile = "chat_history.txt"; // File to store conversation history
    private static List<object> conversationHistory = new();
    private static string selectedModel = "llama3-8b-8192";
    private static string personalityPrompt = "You are a helpful AI assistant";

    static Program()
    {
        if (!client.DefaultRequestHeaders.Contains("Authorization"))
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }
    }
    static async Task<string> GetAIResponse(string userInput)
    {
        conversationHistory.Add(new { role = "user", content = userInput });

        var requestData = new
        {
            model = selectedModel,
            messages = conversationHistory
        };

        var jsonRequest = JsonConvert.SerializeObject(requestData);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync(apiUrl, content);
            var responseString = await response.Content.ReadAsStringAsync();
            dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);
            string aiResponse = jsonResponse.choices[0].message.content.ToString();

            conversationHistory.Add(new { role = "assistant", content = aiResponse });

            SaveChatHistory(userInput, aiResponse);

            return aiResponse;
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    private static void SaveChatHistory(string userInput, string aiResponse)
    {
        string logEntry = $"You: {userInput}\nAi: {aiResponse}\n------------------\\n";
        File.AppendAllText(HistoryFile, logEntry);
    }

    private static void LoadChatHistory()
    {
        if (File.Exists(HistoryFile))
        {
            Console.WriteLine("\n🔹 Previous Chat History Loaded:\n");
            string[] historyLines = File.ReadAllLines(HistoryFile);

            foreach (string line in historyLines)
            {
                if (line.StartsWith("You: "))
                {
                    conversationHistory.Add(new { role = "user", content = line.Substring(4) });
                }
                else if (line.StartsWith("AI: "))
                {
                    conversationHistory.Add(new { role = "assistant", content = line.Substring(3) });
                }

            }

            Console.WriteLine(string.Join(Environment.NewLine, historyLines));
        }
        else
        {
            Console.WriteLine("\n🔹 No previous chat history found.");
        }
    }

    static void SelectModel()
    {
        Console.WriteLine("Select an AI Model:");
        Console.WriteLine("1. LLaMA 3 (llama3-8b-8192)");
        Console.WriteLine("2. GPT-3.5 Turbo (gpt-3.5-turbo)");
        Console.WriteLine("3. GPT-4 Turbo (gpt-4-turbo)");
        Console.Write("\nEnter the number of your choice: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                selectedModel = "llama3-8b-8192";
                break;
            case "2":
                selectedModel = "gpt-3.5-turbo";
                break;
            case "3":
                selectedModel = "gpt-4-turbo";
                break;
            default:
                Console.WriteLine("Invalid choice. Using default model (LLaMA 3).");
                selectedModel = "llama3-8b-8192";
                break;
        }
    }
    static void SetPersonality()
    {
        Console.Write("\nSet AI Personality (e.g., 'You are a sarcastic AI'): ");
        personalityPrompt = Console.ReadLine();
        conversationHistory.Add(new { role = "system", content = personalityPrompt });
        Console.WriteLine("\n✅ Personality set!");
    }

    static async Task Main()
    {
        Console.WriteLine("Welcome to your AI chatbot! Type 'exit' to quit.");

        SelectModel();
        SetPersonality();
        LoadChatHistory();

        while (true)
        {
            Console.Write("\nYou: ");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "exit" || userInput.ToLower() == "quit")
            {
                Console.WriteLine("\nGoodbye! 👋");
                break;
            }

            string response = await GetAIResponse(userInput);
            Console.WriteLine("AI: " + response);
        }
    }
}