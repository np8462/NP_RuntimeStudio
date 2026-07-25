using NP.Core.Models;

namespace NP.Storage.Models
{
    public class ConfigModel
    {
        public string AiProviderUrl { get; set; }
        public string AiApiKey { get; set; }
        public string AiModel { get; set; }
        public int TimeoutSeconds { get; set; }
    }
}