using System;
using System.Collections.Generic;
using System.Linq;
using NP.Core.Models;

namespace NP.Storage.Indexing
{
    public class ChatIndexer
    {
        public List<ChatMessage>
            Search(
                List<ChatMessage> source,
                string keyword)
        {
            if (string.IsNullOrWhiteSpace(
                keyword))
            {
                return source;
            }

            return source
                .Where(
                    x =>
                        x.Content != null &&
                        x.Content.IndexOf(
                            keyword,
                            StringComparison.OrdinalIgnoreCase)
                        >= 0)
                .ToList();
        }
    }
}