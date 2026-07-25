using NP.Core.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace NP.Storage.JsonStorage
{
    public class JsonChatStorage
    {
        private string filePath =
            "ChatHistory.json";

        public List<ChatMessage> Load()
        {
            if (!File.Exists(filePath))
            {
                return new List<ChatMessage>();
            }

            string json =
                File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject
                <List<ChatMessage>>(json);
        }

        public void Save(List<ChatMessage> list)
        {
            string json =
                JsonConvert.SerializeObject(
                    list,
                    Formatting.Indented);

            File.WriteAllText(filePath, json);
        }
    }
}