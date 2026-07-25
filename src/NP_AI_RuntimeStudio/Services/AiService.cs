using System;
using System.Threading.Tasks;
using NP.Core.Models;
using NP.AI.Builders;
using NP.AI.Parsers;
using NP.Storage.Repositories;

namespace NP.AI.Services
{
    public class AiService
    {
        private readonly IAiProvider aiProvider;
        private readonly ChatRepository storage;

        private readonly Action<ChatMessage> appendMessage;

        public AiService(
            IAiProvider provider,
            ChatRepository repo,
            Action<ChatMessage> appendCallback)
        {
            aiProvider = provider;
            storage = repo;
            appendMessage = appendCallback;
        }

        public async Task<string> AskAiAsync(AiContext context)
        {
            string prompt =
                PromptBuilder.Build(context);

            string response =
                await aiProvider.SendAsync(prompt);

            ChatMessage msg = new ChatMessage
            {
                Id = Guid.NewGuid(),
                SessionId = "MAIN",
                Role = "Assistant",
                Content = AiResponseParser.ExtractText(response),
                RawContent = response,
                Type = MessageType.AIResponse,
                CreatedAt = DateTime.Now,
                ColorTag = "AIResponse"
            };

            storage.Save(new System.Collections.Generic.List<ChatMessage> { msg });

            //appendMessage?.Invoke(msg);

            return response;
        }
    }
}