using Newtonsoft.Json;
using NP.Core.Models;
using System.Collections.Generic;
using System.IO;

namespace NP.Host.Storage
{
    public class JsonChatStorage
    {
        private string folder =
            "Data";

        private string file =
            "Data/ChatHistory.json";

        public JsonChatStorage()
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(file))
            {
                File.WriteAllText(file, "[]");
            }
        }

        public List<ChatMessage> Load()
        {
            string json =
                File.ReadAllText(file);

            return JsonConvert.DeserializeObject
                <List<ChatMessage>>(json);
        }

        public void Save(
            List<ChatMessage> messages)
        {
            string json =
                JsonConvert.SerializeObject(
                    messages,
                    Formatting.Indented);

            File.WriteAllText(file, json);
        }
    }
}