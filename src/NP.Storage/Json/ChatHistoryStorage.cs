using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NP.Core.Models;

public class ChatHistoryStorage
{
    private readonly string _filePath;

    public ChatHistoryStorage(
        string filePath)
    {
        _filePath = filePath;
    }

    public List<ChatMessage> Load()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                return new List<ChatMessage>();
            }

            string json =
                File.ReadAllText(
                    _filePath);

            List<ChatMessage> items =
                JsonConvert.DeserializeObject
                <List<ChatMessage>>(json);

            return items ??
                new List<ChatMessage>();
        }
        catch
        {
            return new List<ChatMessage>();
        }
    }

    public void Save(string projectName, string chatName, List<ChatMessage> messages)
    { }

    public void Save(
        List<ChatMessage> messages)
    {
        try
        {
            string json =
                JsonConvert.SerializeObject(
                    messages,
                    Formatting.Indented);

            File.WriteAllText(
                _filePath,
                json);
        }
        catch
        {
        }
    }
}