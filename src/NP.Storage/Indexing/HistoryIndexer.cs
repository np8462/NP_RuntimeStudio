using NP.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System;

public class HistoryIndexer
{
    public List<ChatMessage>
        Search(
            List<ChatMessage> source,
            string keyword)
    {
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