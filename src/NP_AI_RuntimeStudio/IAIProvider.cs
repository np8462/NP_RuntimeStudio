using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.AI
{
    public interface IAiProvider
    {
        Task<string> SendAsync(string prompt);
    }
 
    public class DummyAiProvider : IAiProvider
    {
        public Task<string> SendAsync(string prompt)
        {
            return Task.FromResult("AI: " + prompt);
        }
    }
}